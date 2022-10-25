using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;  
    public static AudioManager instance;
    public AudioMixerGroup musicMixer, sfxMixer;
    [SerializeField] private AudioMixer audioMixer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);//Destroys other instances of AudioManager if one already exists, prevents duplicate
        }

        DontDestroyOnLoad(gameObject);//Keeps samme instance of AudioManager GameObject through scene changes

        foreach (Sound s in sounds)//Accesses audio sources and their configurations
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

        }

    }

    void Start()
    {
        //Calls AdjustVolume functions to set volume of Music and SFX mixers to the respective values saved in PlayerPrefs
        AdjustMusicVolume();
        AdjustSFXVolume(); 
    }

    public void AdjustMusicVolume()
    {

        Debug.Log("AdjustMusicVolume - Value in Music mixer is: " + PlayerPrefs.GetFloat("MusicVolume",1));

        audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", 1));//Adjusts Music Mixer value to PlayerPref value

        Play("BgMusic");//Calls Play function to play background music once volume has been set

    }

    public void AdjustSFXVolume()
    {

        Debug.Log("AdjustSFXVolume - Value in SFX mixer is: " + PlayerPrefs.GetFloat("SFXVolume",1));

        audioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume",1));//Adjusts sound effects mixer value to PlayerPref value

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);//Finds audio source in array

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found! ");
            return;
        }

        if (name == "BgMusic")//Background music uses Music Mixer for output
        {
            s.source.outputAudioMixerGroup = musicMixer;
        }

        else//All other audio sources use SFX Mixer for output
        {
            s.source.outputAudioMixerGroup = sfxMixer;
        }

        s.source.Play();//Plays Audio source

        DontDestroyOnLoad(s.source);//Prevents audio source from stopping when scenes transition
    }

}