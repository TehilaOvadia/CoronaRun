using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    LevelManager gameLevelManager;

    private void Awake()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    public void PlayGame()
    {
        gameLevelManager.LoadGameData();

        if (gameLevelManager != null)
        {
            gameLevelManager.LoadSceneTransition();
            SceneManager.LoadScene(gameLevelManager.levelNum);
        }
        else
        {
            gameLevelManager.LoadSceneTransition();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            gameLevelManager.healthAmount = 5;
            gameLevelManager.hasSyringe = false;
            gameLevelManager.levelNum = SceneManager.GetActiveScene().buildIndex + 1;

            gameLevelManager.SaveGameData();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
