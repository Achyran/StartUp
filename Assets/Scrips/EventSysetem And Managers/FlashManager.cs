using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashManager : MonoBehaviour
{
    private ParticleSystem _ps;
    void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        GameMaster.current.event_PlayerChange += PlayFlash;
    }

    void PlayFlash(GameMaster.Animal pAnimal)
    {
        _ps.Play();
        
    }
    private void OnDestroy()
    {
        GameMaster.current.event_PlayerChange -= PlayFlash;
    }
}
