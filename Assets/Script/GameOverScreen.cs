using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    LevelManager gameLevelManager;
    SceneTransition endSceneTransition;

    private void Awake()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
        endSceneTransition = FindObjectOfType<SceneTransition>();
    }

    public void SetUp()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        //Scene transition
        endSceneTransition.EndScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitButton()
    {
        gameLevelManager.SaveGameData();
        //Scene transition
        endSceneTransition.EndScene();

        SceneManager.LoadScene("MainMenu");
    }
}
