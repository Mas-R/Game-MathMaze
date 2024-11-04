using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Sound2
{
    public string name;
    public AudioClip clip;
    public float volume;
    public float pitch;

    [HideInInspector]
    public AudioSource source;

}
