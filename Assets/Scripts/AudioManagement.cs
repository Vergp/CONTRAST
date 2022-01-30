using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public Sound[] sounds;
    

    public static AudioManagement instance;
    public Sound currentSound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in sounds)
        {    
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Background");
    }
    
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){
            Debug.LogWarning("Som: " + name + " não encontrado!");
            return;
        }
        currentSound = s;
        s.source.Play();
    }

    public void SetVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = volume;
        }
    }

    public float GetVolume()
    {
        return sounds[0].source.volume;
    }
}
