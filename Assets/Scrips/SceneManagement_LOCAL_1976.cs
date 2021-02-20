using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public float delayTime = 5f;
    private bool canStart = true;

    public void StartGame()
    {
        if (canStart)
        {
            Debug.Log("STARTING GAME");
            Invoke("DelayedAction", delayTime);
            canStart = false;
        }
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

    public void DelayedAction()
    {
        SceneManager.LoadScene("Tobi Sceene");
    }
}
