using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnBuildingOnClick : MonoBehaviour
{
    [SerializeField] GameObject buildPrefab = null;
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
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("mouse press");
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Ground")
                {
                    GameObject newObj;
                    newObj = Instantiate(buildPrefab, new Vector3(hit.point.x, hit.point.y + buildPrefab.transform.position.y, hit.point.z), new Quaternion(-0.7071f, 0, 0, 0.7071f));
                    newObj.tag = "Building";
                    newObj.AddComponent<MeshCollider>();
                }
            }
        }
    }
}
