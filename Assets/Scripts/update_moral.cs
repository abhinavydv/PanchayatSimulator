using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class update_moral : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Update()
    {
        int update = SpawnBuildingOnClick.score;
        scoreText.text = update.ToString();
    }
}
