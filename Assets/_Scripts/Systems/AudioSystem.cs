using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : Singleton<AudioSystem>
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundsSource;

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    public void PlaySound(AudioClip clip, Vector2 pos, float vol = 1)
    {
        PlaySound(clip, pos, vol);
    }

    public void PlaySound(AudioClip clip, float vol = 1)
    {
        _soundsSource.PlayOneShot(clip, vol);
    }
}
