using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiTextManager : MonoBehaviour
{
    private TextMeshProUGUI textfield;
    public Image image;

    private void Start()
    {
        textfield = GetComponent<TMPro.TextMeshProUGUI>();
        textfield.text = "";
        textfield.enabled = false;
        GameMaster.current.event_ShowText += SetText;
        GameMaster.current.event_StopShowingText += DisabelText;
        image.color = new Vector4(0, 0, 0, 0);
    }

    private void SetText(string text)
    {
        textfield.enabled = true;
        textfield.text = text;
        
        image.color = new Vector4(255, 255, 255, 255);
    }

    private void DisabelText()
    {
        textfield.text = "";
        textfield.enabled = false;
        image.color = new Vector4(0, 0, 0, 0);
    }
    private void OnDestroy()
    {
        GameMaster.current.event_ShowText -= SetText;
        GameMaster.current.event_StopShowingText -= DisabelText;
    }

}
