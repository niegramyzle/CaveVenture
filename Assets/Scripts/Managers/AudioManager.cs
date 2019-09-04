using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<SoundItem> sounds;
    public static AudioManager instance;

    private void Awake()
    {
        Debug.Log("AudiManagerAw");
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
            sound.audioSource.clip = sound.audioClipSound;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
        }
    }

    public void PlaySound(string _audioClipName)
    {
        sounds.Find(soundItem=> soundItem.audioClipName == _audioClipName).audioSource.Play();
    }
}
