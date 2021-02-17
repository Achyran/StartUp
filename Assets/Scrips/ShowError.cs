using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowError : MonoBehaviour
{
    //TODO: make public private?
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

        //Disable main menu buttons
        //playButton.gameObject.SetActive(false);
        //optionsButton.gameObject.SetActive(false);
        //extrasButton.gameObject.SetActive(false);
        //exitButton.gameObject.SetActive(false);
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

        //Enable main menu buttons
        //playButton.gameObject.SetActive(true);
        //optionsButton.gameObject.SetActive(true);
        //extrasButton.gameObject.SetActive(true);
        //exitButton.gameObject.SetActive(true);
        playButton.interactable = true;
        optionsButton.interactable = true;
        extrasButton.interactable = true;
        exitButton.interactable = true;
    }
}
