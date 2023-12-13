using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapObject
{
    public string name;
    public string type;    // type of the object (Building, road, )
    public Vector2 pos;   // position of the bottom left corner of the object
    public Vector2 size;   // no. of tiles in x and y direction
    public int rotation;   // rotation along z-axis

    public MapObject(string name, string type, Vector2 pos, Vector2 size, int rotation)
    {
        this.name = name;
        this.type = type;
        this.pos = pos;
        this.size = size;
        this.rotation = rotation;
    }
}
