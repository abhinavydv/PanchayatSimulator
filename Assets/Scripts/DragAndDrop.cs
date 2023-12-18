using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    private Camera cam;
    private Vector3 screen_point;
    private Vector3 offset;
    
    void OnMouseDown()
    {
        screen_point = cam.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screen_point.y, Input.mousePosition.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, screen_point.y, Input.mousePosition.z);
        Vector3 curPosition = cam.ScreenToWorldPoint(curScreenPoint) + offset;
        gameObject.transform.position = curPosition;
    }
}   
