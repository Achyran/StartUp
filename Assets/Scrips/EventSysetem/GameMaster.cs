using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMaster : MonoBehaviour
{
    public static GameMaster current;
    public enum Animal {wolf,eagle};
    public Animal currentAnimal;
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

    public event Action<Animal> event_PlayerChange;

    public void PlayerChange(Animal animalIndex)
    {
        if (currentAnimal == animalIndex) { Debug.LogError("Same Animal Returning "); return; }
        currentAnimal = animalIndex;
        if(event_PlayerChange != null)
        {
            event_PlayerChange(animalIndex);
        }
    }
}
