using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonSound : MonoBehaviour
{
    public AudioSource myAudioSource;
    public AudioClip hoverSound;
    public Button myButton;

    public void HoverSound()
    {
        if (myButton.interactable)
        {
            myAudioSource.PlayOneShot(hoverSound);
        }
    }
}
