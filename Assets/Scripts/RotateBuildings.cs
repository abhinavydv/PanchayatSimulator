using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateBuildings : MonoBehaviour
{
    private Camera cam = null;
    public float rotSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        rotateBuilding();
    }

    void rotateBuilding()
    {
        if (Input.GetKey("r"))
        {
            // Debug.Log("r down");
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Building")
                {
                    hit.collider.gameObject.transform.Rotate(0,Time.deltaTime*rotSpeed,0);
                }
            }
        }
    }
}
