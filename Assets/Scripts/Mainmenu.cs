using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Terrain");
    }

    public void exit()
    {
        Application.Quit(); //for game
        UnityEditor.EditorApplication.isPlaying = false; // for editor
    }
}
