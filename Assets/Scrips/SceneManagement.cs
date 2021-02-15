using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("START GAME");
        SceneManager.LoadScene("Tobi Sceene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

    public void ShowError()
    {
        Debug.Log("Sorry this function is not available yet");
    }
}
