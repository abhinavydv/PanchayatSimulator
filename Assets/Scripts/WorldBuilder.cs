using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public TextAsset mapFile;
    // Start is called before the first frame update
    void Start()
    {
        Map map = JsonUtility.FromJson<Map>(mapFile.text);
        Build(map);
    }


    void Build(Map map)
    {
        for (int i=0; i<map.objects.Count; i++){
            MapObject obj = map.objects[i];
            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + obj.name);
            // Debug.Log(prefab);
            // Debug.Log("Prefabs/" + obj.name);
            GameObject go = Instantiate(prefab, new Vector3(obj.pos.x, prefab.transform.position.y, obj.pos.y), Quaternion.Euler(0, 0, obj.rotation));
            go.AddComponent<MeshRenderer>();
            go.transform.localScale = new Vector3(go.transform.localScale.x * obj.size.x, go.transform.localScale.y * obj.size.y, 1);
            Debug.Log(go.GetComponent<MeshRenderer>().bounds.size);
        }
    }
}
