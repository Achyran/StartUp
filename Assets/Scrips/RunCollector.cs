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
        Subscripe();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        GameMaster.current.Collected(index);
    }


    public void Collected(int pIndex)
    {
        if(pIndex == index && isCollectable)
        {
            UnSubscripe();
            isCollectable = false;
            Debug.Log("Rune Collected");
        }
    }
    public void Subscripe() { GameMaster.current.event_Collected += Collected;}
    public void UnSubscripe() { GameMaster.current.event_Collected -= Collected; }
}
