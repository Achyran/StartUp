using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMaster : MonoBehaviour
{
    static public GameMaster curent;

    private void Awake()
    {
        if(curent == null)
        {
            curent = this;
        }
        else
        {
            Debug.Log("GameMaster allready exists, Distroying this!");
            Destroy(this);
        }
    }

    public event Action event_EnterPast;

    public void EnterPast()
    {
        if(event_EnterPast != null)
        {
            event_EnterPast();
        }
    }

    public event Action event_EnterPresent;

    public void EnterPresent()
    {
        if(event_EnterPresent != null)
        {
            event_EnterPresent();
        }
    }
}
