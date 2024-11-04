using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public Sound1[] sound1s;
    public Sound2[] sound2s;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound1 s in sound1s)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = 1f;
            s.source.pitch = 1f;
        }
        foreach (Sound2 s in sound2s)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = 1f;
            s.source.pitch = 1f;
        }
    }

    public void PlayOperator()
    {
        int x = UnityEngine.Random.Range(0, 8);
        Sound1 s = sound1s[x];
        s.source.Play();
    }

    public void CheckFinish(string name)
    {
        
        Sound2 s = Array.Find(sound2s, sound => sound.name == name);
        s.source.Play();
    }
    public void ButtonClck()
    {

        Sound2 s = Array.Find(sound2s, sound => sound.name == "Button");
        s.source.Play();
    }
}
