using UnityEngine.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager current;
    private float musikcheck;
    private float backgroundMusikCd;
 
    void Awake()
    {
        if(current == null)
        {
            current = this;
        }
        else
        {
            Debug.LogWarning("Mulitble Soundmanagers, destroing this");
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds)
        {
            if(s.gameObjects.Count == 0)
            {
                s.source = gameObject.AddComponent<AudioSource>();
            }
            else
            {
                for(int i = 0; i <s.gameObjects.Count; i ++ )
                {
                    s.source = s.gameObjects[i].AddComponent<AudioSource>();
                }
            }
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound target = null;
        foreach(Sound s in sounds)
        {
            if (s.name == name) target = s;
        }

        if( target == null)
        {
            Debug.LogWarning("Sound " + target + "Was not found");
            return;
        }
        target.source.Play();
        
    }
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + s + "Was not found");
            return;
        }
        s.source.Pause();
    }
    public bool isPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + s + "Was not found");
            return false;
        }
        return s.source.isPlaying;
    }
    private void Update()
    {
        BackgroundMusik();
        Eneviroment();
    }
    private void Eneviroment()
    {
        if (backgroundMusikCd <= 0)
        {
            Play("Sound_Enviroment");
            backgroundMusikCd = UnityEngine.Random.Range(30, 60);
        }
        else backgroundMusikCd -= Time.deltaTime;
    }
    private void BackgroundMusik()
    {

        if (musikcheck <= 0)
        {
            musikcheck = 30;
            if (!isPlaying("Musik_dreaming") && !isPlaying("Musik_forest") && !isPlaying("Musik_main"))
            {
                int rand = UnityEngine.Random.Range(0,3);
                switch (rand)
                {
                    case 0:
                        Play("Musik_dreaming");
                        break;
                    case 1:
                        Play("Musik_forest");
                        break;
                    case 2:
                        Play("Musik_main");
                        break;
                }
            }
        }
        else { musikcheck -= Time.deltaTime; }
    }


}
