using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    private void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
        else
        {
            Debug.LogError("GameMaster allready exist, Destroying this !");
            Destroy(gm);
        }
    }

    public event Action<int> event_PlayerChange;

    public void PlayerChange(int animalIndex)
    {
        if(event_PlayerChange != null)
        {
            event_PlayerChange(animalIndex);
        }
    }
}
