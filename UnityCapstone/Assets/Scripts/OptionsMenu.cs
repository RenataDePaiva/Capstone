using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider MusicSlider, SFXSlider;
    public GameObject OptionsCanvas;
    public GameObject CreditsCanvas;

    void Awake()
    {
        CreditsCanvas.SetActive(false);
        MusicSlider.value = PlayerPrefs.GetFloat("MusicSliderValue",1);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXSliderValue",1);
    }

    public void SetMusicVolume(float musicSliderValue)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicSliderValue) *20);
        PlayerPrefs.SetFloat("MusicVolume", Mathf.Log10(musicSliderValue) * 20);
        Debug.Log("Value in Music Mixer : " + Mathf.Log10(musicSliderValue) * 20);
        PlayerPrefs.Save();

        PlayerPrefs.SetFloat("MusicSliderValue", musicSliderValue);
        Debug.Log("Value in Slider : " + musicSliderValue);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float sfxSliderValue)
    {
        Debug.Log("SFX Slider Value is: " + sfxSliderValue);

        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxSliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", Mathf.Log10(sfxSliderValue) * 20);
        Debug.Log("Value in Music Mixer : " + Mathf.Log10(sfxSliderValue) * 20);
        PlayerPrefs.Save();

        PlayerPrefs.SetFloat("SFXSliderValue", sfxSliderValue);
        Debug.Log("Value in Slider : " + sfxSliderValue);
        PlayerPrefs.Save();
    }

    public void CreditsMenu()
    {
        OptionsCanvas.SetActive(false);
        CreditsCanvas.SetActive(true);
    }

    public void BackToOptions()
    {
        OptionsCanvas.SetActive(true);
        CreditsCanvas.SetActive(false);
    }
}
