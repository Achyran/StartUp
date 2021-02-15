using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowError : MonoBehaviour
{
    public Image errorImage;
    public Button errorButton;

    private void Start()
    {
        errorImage.enabled = false;
        errorButton.gameObject.SetActive(false);
    }

    public void OpenError()
    {
        errorImage.enabled = true;
        errorButton.gameObject.SetActive(true);
    }

    public void CloseError()
    {
        errorImage.enabled = false;
        errorButton.gameObject.SetActive(false);
    }
}
