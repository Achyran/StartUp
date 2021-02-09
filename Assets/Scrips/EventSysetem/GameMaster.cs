using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMaster : MonoBehaviour
{
    public static GameMaster current;
    private void Awake()
    {
        if(current == null)
        {
            current = this;
        }
        else
        {
            Debug.LogError("GameMaster allready exist, Destroying this !");
            Destroy(current);
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
