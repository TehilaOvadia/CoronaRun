using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    LevelManager gameLevelManager;

    void Awake()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        gameLevelManager.LoadGameData();

        SetVolume(gameLevelManager.effectVolume);
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("The sound: " + name + " not found!");
            return;
        }
            
        s.source.Play();
    }

    public void StopPlay(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("The sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    public void SetVolume(float volume)
    {
        gameLevelManager.effectVolume = volume;

        foreach (Sound s in sounds)
        {
            //s.source = gameObject.AddComponent<AudioSource>();
            s.source.volume = volume;
            s.volume = volume;

            Debug.Log("s.source.name: " + s.source.name);
            Debug.Log("s.source.volume: " + s.source.volume);
            Debug.Log("s.name: " + s.name);
            Debug.Log("s.volume: " + s.volume);
            Debug.Log("volume: " + volume);
        }
    }
}
