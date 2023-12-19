using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class update_money : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Update()
    {
        int update = SpawnBuildingOnClick.wallet;
        scoreText.text = update.ToString();
    }
}
