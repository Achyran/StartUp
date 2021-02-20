using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCollector : MonoBehaviour, ICollectable
{
    public bool isCollectable { get; set; } = true;
    public int index;
    public string text;



    // Start is called before the first frame update
    void Start()
    {
        isCollectable = true;
        ICollectable_Subscripe();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isCollectable)
            {
                isCollectable = false;
                GameMaster.current.Collected(index);
                AudioManager.current.Play("Sound_rune_Collection");
            }
            GameMaster.current.ShowText(text);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            GameMaster.current.StopShowingText();
        }
    }


    public void Collected(int pIndex)
    {
        if(pIndex == index && isCollectable)
        {
            ICollectable_UnSubscripe();
            isCollectable = false;
            Debug.Log("Rune Collected");
        }
    }
    public void ICollectable_Subscripe() { GameMaster.current.event_Collected += Collected;}
    public void ICollectable_UnSubscripe() { GameMaster.current.event_Collected -= Collected;}

}
