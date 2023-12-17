using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Map
{
    public List<Structure> structures;
    List<Structure> selectedObjects;

    public Map()
    {
        structures = new List<Structure>();
        selectedObjects = new List<Structure>();
    }
}
