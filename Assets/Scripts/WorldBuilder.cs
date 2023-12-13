using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public TextAsset mapFile;
    // Start is called before the first frame update
    void Start()
    {
        Map map = JsonUtility.FromJson<Map>(mapFile.text);
        Build(map);
    }



    void Build(Map map)
    {

    }
}
