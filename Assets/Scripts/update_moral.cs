using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class update_moral : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Update()
    {
        int update = SpawnBuildingOnClick.score;
        scoreText.text = update.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
