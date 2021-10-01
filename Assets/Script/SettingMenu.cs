using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    //public AudioMixer audioMixer;
    LevelManager gameLevelManager;

    private void Awake()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    public void SetBGVolume(float volume)
    {
        //audioMixer.SetFloat("bgVolume", volume);
    }

    public void SetEffectVolume(float volume)
    {

    }

    public void RestartGame()
    {
        gameLevelManager.healthAmount = 5;
        gameLevelManager.hasSyringe = false;
        gameLevelManager.levelNum = 1;

        gameLevelManager.SaveGameData();
    }
}
