using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public float delayTime = 5f;
    public Button playButton;
    public Button optionsButton;
    public Button extrasButton;
    public Button exitButton;

    public void StartGame()
    {
        Debug.Log("STARTING GAME");
        playButton.interactable = false;
        optionsButton.interactable = false;
        extrasButton.interactable = false;
        exitButton.interactable = false;
        Invoke("DelayedAction", delayTime);
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