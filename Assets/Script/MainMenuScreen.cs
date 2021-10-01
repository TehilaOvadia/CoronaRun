using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    LevelManager gameLevelManager;
    SceneTransition endSceneTransition;

    private void Awake()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
        endSceneTransition = FindObjectOfType<SceneTransition>();
    }

    public void PlayGame()
    {
        gameLevelManager.LoadGameData();

        if (gameLevelManager != null)
        {
            //Scene transition
            endSceneTransition.EndScene();

            SceneManager.LoadScene(gameLevelManager.levelNum);
        }
        else
        {
            gameLevelManager.healthAmount = 5;
            gameLevelManager.hasSyringe = false;
            gameLevelManager.levelNum = SceneManager.GetActiveScene().buildIndex + 1;

            gameLevelManager.SaveGameData();

            //Scene transition
            endSceneTransition.EndScene();
            SceneManager.LoadScene(gameLevelManager.levelNum);
        }
    }

    public void QuitGame()
    {
        //Scene transition
        endSceneTransition.EndScene();

        Application.Quit();
    }
}
