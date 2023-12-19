using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyOnClick : MonoBehaviour
{
    private Camera cam = null;
    int buildingCount;
    public int redScore = 40;
    public int redWallet = 10000;   
    
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
                if (hit.collider.gameObject.tag == "Building" || hit.collider.gameObject.tag == "NewBuilding")
                {
                    // Debug.Log("destroyed go");
                    Destroy(hit.collider.gameObject);
                    SpawnBuildingOnClick.score -= redScore;
                    SpawnBuildingOnClick.wallet -= redWallet;
                }
            }
        }
    }
}
