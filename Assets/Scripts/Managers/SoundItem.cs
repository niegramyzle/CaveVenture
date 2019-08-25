using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundItem
{
    [SerializeField] private string audioClipName;
    public string AudioClipName { get { return audioClipName; } }

    [SerializeField] private AudioClip audioClipSound;
    public AudioClip AudioClipSound
    { get { return audioClipSound; } set { audioClipSound = value; } }

    [SerializeField] [Range(0, 1.0f)] private float volume = 0.5f;
    public float Volume
    { get { return volume; } set { volume = value; } }
    
    [SerializeField] [Range(0.5f, 1.5f)] private float pitch = 1f;
    public float Pitch
    { get { return pitch; } set { pitch = value; } }

    public AudioSource audioSource { get; set; }
}
