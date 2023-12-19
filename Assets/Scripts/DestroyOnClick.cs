using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyOnClick : MonoBehaviour
{
    private Camera cam = null;
    int buildingCount;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        DeleteAtMousePosn();
    }

    void DeleteAtMousePosn()
    {
        if (Input.GetKeyDown("x"))
        {
            // Debug.Log("x down");
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Building")
                {
                    spawnPoint = new Vector3(hit.point.x, hit.point.y + list[i].transform.position.y, hit.point.z);
                    // Debug.Log("destroyed go");
                    Destroy(hit.collider.gameObject);
                    reduceScore()
                }
                else if(hit.collider.gameObject.tag == "NewBuilding")
                {
                    reduceScore(i, )
                }
            }
        }
    }

    void reduceScore(int buildingIndex, Vector3 spawnPoint)
    {
        buildingCount = SpawnBuildingOnClick.cast(spawnPoint);
        SpawnBuildingOnClick.score-=(buildingCount*SpawnBuildingOnClick.moralityIndex[buildingIndex]);
    }
}
