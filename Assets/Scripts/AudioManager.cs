using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioInstance;

    public SoundClass[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource, sfxOneShotSource;

    private void Awake()
    {
        if (AudioInstance == null)
        {
            AudioInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("MenuTheme");
    }

    public void PlayMusic(string name)
    {
        SoundClass s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFXOneShot(string name)
    {
        SoundClass s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            sfxOneShotSource.PlayOneShot(s.clip);
        }
    }

    public void PlaySFX(string name)
    {
        SoundClass s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }
}
