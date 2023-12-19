using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class update_score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    void Update()
    {
        int update_s = SpawnBuildingOnClick.score;
        scoreText.text = update_s.ToString();  
    }
}
