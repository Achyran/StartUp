using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMaster : MonoBehaviour
{
    public static GameMaster current;
    public List<GameObject> AnimalModels;
    public enum Animal {wolf,eagle};
    public Animal currentAnimal;

    //-------------------IngameStats------------------------//
    public int runeScore { get; private set; }
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
            return;
        }
    }

    public event Action<Animal> event_PlayerChange;
    public void PlayerChange(Animal animalIndex)
    {
        if (currentAnimal == animalIndex)   return; 
        currentAnimal = animalIndex;
        if(event_PlayerChange != null && runeScore >= 3)
        {
            AudioManager.current.Play("Sound_transformation");
            event_PlayerChange(animalIndex);
        }
    }
    public event Action<int> event_Collected;

    public void Collected(int pIndex)
    {
        if (event_Collected != null)
        {
            runeScore++;
            event_Collected(pIndex);
        }
    }
    public event Action<string> event_ShowText;

    public void ShowText(string pText)
    {
        if (event_ShowText != null)
        {
            if (runeScore == 3) pText += "\n \n you feal Empowerd, hold f to transform";
            event_ShowText(pText);
        }
    }
    public event Action event_StopShowingText;

    public void StopShowingText()
    {
        if (event_ShowText != null)
        {
            event_StopShowingText();
        }
    }
}
