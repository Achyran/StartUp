using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("STARTING GAME");
        SceneManager.LoadScene("Tobi Sceene");
        //SceneManager.LoadScene("AmkesScene");
    }

    public void QuitGame()
    {
        Debug.Log("QUITTING GAME");
        Application.Quit();
    }

    public void ShowErrorMessage()
    {
        Debug.Log("This function is not available yet");
    }    
}
