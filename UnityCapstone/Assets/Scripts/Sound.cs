using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class Sound //Class of audio sources
{
    public string name;
    public AudioClip clip;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
