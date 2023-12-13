using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject
{
    string name;
    string type;    // type of the object (Building, road, )
    Vector2 position;   // position of the bottom left corner of the object
    Vector2 size;   // no. of tiles in x and y direction
    int rotation;   // rotation along z-axis
}
