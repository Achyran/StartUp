using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCollector : MonoBehaviour, ICollectable
{
    public bool isCollectable { get; set; }
    public int index { get; set; }



    // Start is called before the first frame update
    void Start()
    {
        isCollectable = true;
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Collected();
        }
    }


    public void Collected()
    {
        if(isCollectable)
        {
            isCollectable = false;
            GameMaster.current.runeScore++;
            Debug.Log("RuneCollected");
        }
    }
}
