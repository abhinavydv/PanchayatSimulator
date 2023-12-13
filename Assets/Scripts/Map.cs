using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Map
{
    public List<MapObject> objects;
    List<MapObject> selectedObjects;

    public Map()
    {
        objects = new List<MapObject>();
        selectedObjects = new List<MapObject>();
    }
}
