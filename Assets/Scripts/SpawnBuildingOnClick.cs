using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Linq;

public class SpawnBuildingOnClick : MonoBehaviour
{
    [SerializeField] List<GameObject> list;
    [SerializeField] List<int> Costs;
    [SerializeField] List<int> moralityIndex;
    private Camera cam = null;
    
    Vector3 spawnPoint;
    int buildingCount;
    [SerializeField] int initialWallet;
    [SerializeField] int benefitRadius;
    int wallet;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        score = 0;
        wallet = initialWallet;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAtMousePosn();
        Debug.Log(score + " " + wallet);
    }

    void SpawnAtMousePosn()
    {
        for (int i=0; i<list.Count; i++)
        {
            if (Input.GetKeyDown((i+1).ToString())){
                Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Ground")
                    {
                        GameObject newObj;
                        spawnPoint = new Vector3(hit.point.x, hit.point.y + list[i].transform.position.y, hit.point.z);
                        newObj = Instantiate(list[i], spawnPoint, Quaternion.identity);
                        newObj.tag = "NewBuilding"; 
                        newObj.AddComponent<MeshCollider>();
                        addScore(i, spawnPoint);
                        ReduceWallet(i);
                    }
                }
            }
        }
    }

    int cast(Vector3 spawnPoint)
    {
        //Add layers here to only detect the buildings
        Collider[] hitBuildings = Physics.OverlapSphere(spawnPoint, benefitRadius);
        return hitBuildings.Count();
    }
    
    void addScore(int buildingIndex, Vector3 spawnPoint)
    {
        buildingCount = cast(spawnPoint);
        score+=(buildingCount * moralityIndex[buildingIndex]);
    }

    void ReduceWallet(int buildingIndex)
    {
        wallet-=Costs[buildingIndex];
    }
}
