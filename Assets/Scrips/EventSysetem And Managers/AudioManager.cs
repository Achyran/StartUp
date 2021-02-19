using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager current;
 
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

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            if(s.gameObject == null)
            {
                s.source = gameObject.AddComponent<AudioSource>();
            }
            else
            {
                s.source = s.gameObject.AddComponent<AudioSource>();
            }
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    public void Start()
    {
        Play("Start");
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
    


}
