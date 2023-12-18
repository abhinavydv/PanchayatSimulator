using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modualrwindow : MonoBehaviour
{
    public GameObject item;
    public void open()
    {
        item.SetActive(true);
    }

    public void close()
    {
        item.SetActive(false);
    }
 }
