using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;  
    public static AudioManager instance;
    public AudioMixerGroup musicMixer, sfxMixer;
    OptionsMenu optionsMenu;
    [SerializeField] private AudioMixer audioMixer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

        }

    }

    void Start()
    {
        AdjustMusicVolume();
        AdjustSFXVolume();
    }

    public void AdjustMusicVolume()
    {

        Debug.Log("AdjustMusicVolume (if) - Value in Music mixer is: " + PlayerPrefs.GetFloat("MusicVolume",1));

        audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", 1));

        Play("BgMusic");

    }

    public void AdjustSFXVolume()
    {

        Debug.Log("AdjustSFXVolume (if) - Value in SFX mixer is: " + PlayerPrefs.GetFloat("SFXVolume",1));

        audioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume",1));

    }


    //public void ButtonClickSound()
    //{

    //    Play("Button Click");

    //}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found! ");
            return;
        }

        if (name == "BgMusic")
        {
            s.source.outputAudioMixerGroup = musicMixer;
        }

        else
        {
            s.source.outputAudioMixerGroup = sfxMixer;
        }

        DontDestroyOnLoad(s.source);

        s.source.Play();

    }

}