using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Build(parseMap("map.json"));
    }

    Map parseMap(string mapName)
    {
        return null;
    }

    void Build(Map map)
    {

    }
}
