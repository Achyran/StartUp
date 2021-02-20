using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public float delayTime = 5f;
<<<<<<< HEAD
    private bool canStart = true;

    public void StartGame()
    {
        if (canStart)
        {
            Debug.Log("STARTING GAME");
            Invoke("DelayedAction", delayTime);
            canStart = false;
        }
=======
    public Button playButton;

    public void StartGame()
    {
        Debug.Log("STARTING GAME");
        playButton.interactable = false;
        Invoke("DelayedAction", delayTime);
>>>>>>> 6e7a5fb473a00c313f6ca9ed7dad2ca7244e4f5b
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
        SceneManager.LoadScene("TerrainScene");
    }
}
