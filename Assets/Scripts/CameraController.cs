using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraController : MonoBehaviour
{
    public int zoomRate = 10;
    bool isTerrainFocussed;
    // Start is called before the first frame update
    void Start()
    {
        isTerrainFocussed = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            // check if it was a mouse scroll
            float axis = Input.GetAxis("Mouse ScrollWheel");
            moveCamera(new Vector3(0, -1 * axis * zoomRate, 0));
        }
        else if (Input.GetMouseButtonDown(0))
        {
            // check if it was a left click
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(mousePos);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // check if it was a right click
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(mousePos);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            isTerrainFocussed = !isTerrainFocussed;
            if (isTerrainFocussed)
            {
                // focus on terrain
                Debug.Log("Focussing on terrain");
            }
            else
            {
                // focus on selected object
                Debug.Log("Focussing on selected object");
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // deselect object
            Debug.Log("Deselecting object");
        }if (Input.GetKeyDown(KeyCode.Delete))
        {
            // delete object
            Debug.Log("Deleting object");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            // rotate object
            Debug.Log("Rotating object left");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            // rotate object
            Debug.Log("Rotating object right");
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // move up
        {
            // move object up
            if (isTerrainFocussed)
            {
                moveCamera(new Vector3(0, 0, 1));
            }
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // move down
        {
            // move object down
            if (isTerrainFocussed)
            {
                moveCamera(new Vector3(0, 0, -1));
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // move left
        {
            // move object left
            if (isTerrainFocussed)
            {
                moveCamera(new Vector3(-1, 0, 0));
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // move right
        {
            // move object right
            if (isTerrainFocussed)
            {
                moveCamera(new Vector3(1, 0, 0));
            }
        }
    }

    void moveCamera(Vector3 diff)
    {
        gameObject.transform.position += diff;
    }
}
