using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiTextManager : MonoBehaviour
{
    TextMeshProUGUI textfield;

    private void Start()
    {
        textfield = GetComponent<TMPro.TextMeshProUGUI>();
        textfield.text = "";
        textfield.enabled = false;
        GameMaster.current.event_ShowText += SetText;
        GameMaster.current.event_StopShowingText += DisabelText;
    }

    private void SetText(string text)
    {
        textfield.enabled = true;
        textfield.text = text;
    }

    private void DisabelText()
    {
        textfield.text = "";
        textfield.enabled = false;
    }
    private void OnDestroy()
    {
        GameMaster.current.event_ShowText -= SetText;
        GameMaster.current.event_StopShowingText -= DisabelText;
    }

}
