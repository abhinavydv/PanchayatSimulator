using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Terrain 1");
    }

    public void exit()
    {
        Application.Quit(); //for game
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exit();
        }
    }
}
