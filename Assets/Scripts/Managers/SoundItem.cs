using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundItem
{
    public string audioClipName;
    public AudioClip audioClipSound;
    [Range(0, 1.0f)] public float volume = 0.5f;
    [Range(0.5f, 1.5f)] public float pitch = 1f;

    public AudioSource audioSource { get; set; }
}
