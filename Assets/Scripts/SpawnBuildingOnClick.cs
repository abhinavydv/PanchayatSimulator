using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnBuildingOnClick : MonoBehaviour
{
    [SerializeField] List<GameObject> list;
    private Camera cam = null;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAtMousePosn();
    }

    void SpawnAtMousePosn()
    {
        for (int i=0; i<5; i++)
        {
            if (Input.GetKeyDown((i+1).ToString())){
                Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Ground")
                    {
                        GameObject newObj;
                        newObj = Instantiate(list[i], new Vector3(hit.point.x, hit.point.y + list[i].transform.position.y, hit.point.z), Quaternion.identity);
                        newObj.tag = "Building"; 
                        newObj.AddComponent<MeshCollider>();
                    }
                }
            }
        }
    }
}
