using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visability : MonoBehaviour
{
    private MeshRenderer ren;
    public bool  isInPast;

    void Start()
    {
        ren = GetComponent<MeshRenderer>();
        if (isInPast)
        {
            GameMaster.curent.event_EnterPast += Visable;
            GameMaster.curent.event_EnterPresent += InVisable;
            ren.enabled = false;
        }
        else
        {
            GameMaster.curent.event_EnterPast += InVisable;
            GameMaster.curent.event_EnterPresent += Visable;
            ren.enabled = true;
        }
    }

    void InVisable()
    {
        ren.enabled = false;
    }
    
    void Visable()
    {
        ren.enabled = true;
    }

    private void OnDestroy()
    {
        if (isInPast)
        {
            GameMaster.curent.event_EnterPast -= Visable;
            GameMaster.curent.event_EnterPresent -= InVisable;
        }
        else
        {
            GameMaster.curent.event_EnterPast -= InVisable;
            GameMaster.curent.event_EnterPresent -= Visable;
        }
    }
}
