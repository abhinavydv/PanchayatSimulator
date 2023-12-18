using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public TextAsset mapFile;
    public double floor_height;
    public GameObject corner1;
    public GameObject corner2;
    public GameObject terrain;
    public float tarrainScale;
    public float terrainRotation;
    public Vector3 terrainPos;
    List<Mesh> meshes;
    // Start is called before the first frame update
    void Start()
    {
        Map map = JsonUtility.FromJson<Map>(mapFile.text);
        Build(map);
        // TestBuild();
    }

    GameObject Make3D(Vector2[] points, int height){
        float minX = int.MaxValue;
        float minY = int.MaxValue;

        for (int i=0; i<points.Length; i++){
            if (points[i].x < minX) minX = points[i].x;
            if (points[i].y < minY) minY = points[i].y;
        }

        for (int i=0; i<points.Length; i++){
            points[i] = new Vector2(points[i].x - minX, points[i].y - minY);
        }

        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[points.Length * 2];
        int[] triangles = new int[points.Length * 12];

        for (int i = 0; i < points.Length; i++)
        {
            vertices[i] = new Vector3(points[i].x, 0, points[i].y);
            vertices[i + points.Length] = new Vector3(points[i].x, height, points[i].y);

            if (i < points.Length - 1)
            {
                int j = i * 12;
                triangles[j] = i + 1;
                triangles[j + 1] = i + points.Length;
                triangles[j + 2] = i;

                triangles[j + 3] = i + points.Length + 1;
                triangles[j + 4] = i + points.Length;
                triangles[j + 5] = i + 1;

                triangles[j + 6] = i + 1;
                triangles[j + 7] = i;
                triangles[j + 8] = 0;

                triangles[j + 11] = i + 1 + points.Length;
                triangles[j + 10] = i + points.Length;
                triangles[j + 9] = points.Length;
            } else {
                int j = i * 12;
                triangles[j] = 0;
                triangles[j + 1] = i + points.Length;
                triangles[j + 2] = i;

                triangles[j + 3] = points.Length;
                triangles[j + 4] = i + points.Length;
                triangles[j + 5] = 0;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        GameObject go = new GameObject();
        go.AddComponent<MeshFilter>();
        go.AddComponent<MeshRenderer>();

        go.GetComponent<MeshFilter>().mesh = mesh;
        go.name = "Building";

        go.transform.position = new Vector3(minX, 0, minY);

        return go;
    }

    void TestBuild() {
        Vector2[] points = new Vector2[6]{
            new Vector2((float)8646538.384300001, (float)3317219.283399999),
            new Vector2((float)8646539.8134, (float)3317220.3532999977),
            new Vector2((float)8646543.103, (float)3317214.365699999),
            new Vector2((float)8646541.131499998, (float)3317213.4416000023),
            new Vector2((float)8646539.5948, (float)3317216.9070999995),
            new Vector2((float)8646538.384300001, (float)3317219.283399999),
        };

        float minX = int.MaxValue;
        float minY = int.MaxValue;

        for (int i=0; i<points.Length; i++){
            if (points[i].x < minX) minX = points[i].x;
            if (points[i].y < minY) minY = points[i].y;
        }

        for (int i=0; i<points.Length; i++){
            points[i] = new Vector2(points[i].x - minX, points[i].y - minY);
        }

        // for (int i=0; i<points.Length; i++){
        //     Debug.Log("Hello: " + points[i].x + " " + points[i].y);
        // }

        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[points.Length * 2];
        int[] triangles = new int[points.Length * 12];

        for (int i = 0; i < points.Length; i++)
        {
            vertices[i] = new Vector3(points[i].x, 0, points[i].y);
            vertices[i + points.Length] = new Vector3(points[i].x, 2, points[i].y);

            if (i < points.Length - 1)
            {
                int j = i * 12;
                triangles[j] = i + 1;
                triangles[j + 1] = i + points.Length;
                triangles[j + 2] = i;

                triangles[j + 3] = i + points.Length + 1;
                triangles[j + 4] = i + points.Length;
                triangles[j + 5] = i + 1;

                triangles[j + 6] = i + 1;
                triangles[j + 7] = i;
                triangles[j + 8] = 0;

                triangles[j + 11] = i + 1 + points.Length;
                triangles[j + 10] = i + points.Length;
                triangles[j + 9] = points.Length;
            } else {
                int j = i * 12;
                triangles[j] = 0;
                triangles[j + 1] = i + points.Length;
                triangles[j + 2] = i;

                triangles[j + 3] = points.Length;
                triangles[j + 4] = i + points.Length;
                triangles[j + 5] = 0;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        GameObject go = new GameObject();
        go.AddComponent<MeshFilter>();
        go.AddComponent<MeshRenderer>();

        go.GetComponent<MeshFilter>().mesh = mesh;
        go.name = "Building";

        go.transform.position = new Vector3(minX, 0, minY);
    }

    private void Build(Map map)
    {
        float diff = TransformPoints(map.structures);
        TransformTerrain(diff);

        for (int i=0; i<map.structures.Count; i++)
        {
            Structure obj = map.structures[i];
            GameObject go = BuildOne(obj);
            go.transform.parent = transform;
        }
    }

    void TransformTerrain(float diff){
        terrain.transform.position = terrainPos;
        terrain.transform.localScale = new Vector3(tarrainScale, tarrainScale, tarrainScale);
        terrain.transform.Rotate(new Vector3(0, 1, 0), terrainRotation);
    }

    float TransformPoints(List<Structure> structures){
        float minX = int.MaxValue;
        float minY = int.MaxValue;
        float maxX = int.MinValue;
        float maxY = int.MinValue;
        float diff;

        for (int i=0; i<structures.Count; i++){
            for (int j=0; j<structures[i].points.Count; j++){
                if (structures[i].points[j].x < minX) minX = (float)structures[i].points[j].x;
                if (structures[i].points[j].y < minY) minY = (float)structures[i].points[j].y;
                if (structures[i].points[j].x > maxX) maxX = (float)structures[i].points[j].x;
                if (structures[i].points[j].y > maxY) maxY = (float)structures[i].points[j].y;
            }
        }

        diff = maxX - minX;

        for (int i=0; i<structures.Count; i++){
            for (int j=0; j<structures[i].points.Count; j++){
                structures[i].points[j] = new Structure.Point{
                    x = structures[i].points[j].x - minX - diff / 2,
                    y = structures[i].points[j].y - minY - diff / 2
                };
            }
        }

        return diff;
    }

    GameObject BuildOne(Structure obj)
    {
        GameObject go = Make3D(obj.points.Select(p => new Vector2((float)p.x, (float)p.y)).ToArray(), (int)(obj.No_Floors * floor_height));

        Material material = new Material(Shader.Find("Standard"));
        material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1.0f);
        go.GetComponent<MeshRenderer>().material = material;

        return go;
    }
}
