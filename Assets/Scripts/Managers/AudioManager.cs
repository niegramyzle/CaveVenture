using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public List<AudioSource> sounds;

    public void SetBackgroundMusicVolume(float value) 
    {
        backgroundMusic.volume = value;
    }

    public void SetSFXVolume(float value) 
    {
        foreach (AudioSource s in sounds) {
            s.volume = value;
        }
    }
}
