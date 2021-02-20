using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowError : MonoBehaviour
{
    public Image errorImage;
    public Button errorButton;
    public Button playButton;
    public Button optionsButton;
    public Button extrasButton;
    public Button exitButton;
    public Text errorText;

    private void Start()
    {
        errorImage.enabled = false;
        errorButton.gameObject.SetActive(false);
        errorText.gameObject.SetActive(false);
    }

    public void OpenError()
    {
        errorImage.enabled = true;
        errorButton.gameObject.SetActive(true);
        errorText.gameObject.SetActive(true);

        playButton.interactable = false;
        optionsButton.interactable = false;
        extrasButton.interactable = false;
        exitButton.interactable = false;
    }

    public void CloseError()
    {
        errorImage.enabled = false;
        errorButton.gameObject.SetActive(false);
        errorText.gameObject.SetActive(false);

        playButton.interactable = true;
        optionsButton.interactable = true;
        extrasButton.interactable = true;
        exitButton.interactable = true;
    }
}
