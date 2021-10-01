using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    //public AudioMixer audioMixer;
    LevelManager gameLevelManager;

    public Slider slider;

    private void Awake()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        gameLevelManager.LoadGameData();

        slider.value = gameLevelManager.effectVolume;
        //SetVolume(gameLevelManager.effectVolume);
    }

    public void SetBGVolume(float volume)
    {
        //audioMixer.SetFloat("bgVolume", volume);
    }

    public void SetEffectVolume(float volume)
    {
        AudioManager.instance.SetVolume(volume);

        gameLevelManager.SaveGameData();
    }

    public void RestartGame()
    {
        gameLevelManager.healthAmount = 5;
        gameLevelManager.hasSyringe = false;
        gameLevelManager.levelNum = 1;

        gameLevelManager.SaveGameData();
    }
}
