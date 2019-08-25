﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<SoundItem> sounds;
    public static AudioManager instance;

    private void Awake()
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
        foreach (var sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.AudioClipSound;
            sound.audioSource.volume = sound.Volume;
            sound.audioSource.pitch = sound.Pitch;
        }
    }

    public void PlaySound(string _audioClipName)
    {
        sounds.Find(soundItem=> soundItem.AudioClipName == _audioClipName).audioSource.Play();
    }
}
