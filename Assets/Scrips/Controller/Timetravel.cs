using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timetravel : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameMaster.curent.EnterPast();
            Debug.Log("Enter Past");
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            GameMaster.curent.EnterPresent();
            Debug.Log("EnterPresent");
        }
    }

    
}
