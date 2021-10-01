using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    LevelManager gameLevelManager;

    public Slider slider;
    public Text restartSubTxt;
    public Button restartBtn;

    private void Awake()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        gameLevelManager.LoadGameData();

        slider.value = gameLevelManager.effectVolume;

        if(gameLevelManager.levelNum <= 1)
        {
            restartBtn.interactable = false;

            restartSubTxt.text = "";
        }
        else
        {
            restartBtn.interactable = true;

            restartSubTxt.text = "";
        }
    }

    //public void SetBGVolume(float volume)
    //{
        //audioMixer.SetFloat("bgVolume", volume);
    //}

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

        restartBtn.interactable = false;
        restartSubTxt.text = "Restart succesfuly! Enjoy again";
    }
}
