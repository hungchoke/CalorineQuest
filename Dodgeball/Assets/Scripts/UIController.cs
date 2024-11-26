using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            musicSlider.value = savedVolume;
            AudioManager.instance.MusicVolume(savedVolume);
        }
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("SFXVolume");
            sfxSlider.value = savedVolume;
            AudioManager.instance.SFXVolume(savedVolume);
        }
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        float volume = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        AudioManager.instance.MusicVolume(volume);
    }
    public void SFXVolume()
    {
        float volume = sfxSlider.value;
        PlayerPrefs.SetFloat("SFXVolume", volume);
        AudioManager.instance.SFXVolume(volume);
    }
}
