using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    LevelManager gameLevelManager;

    private void Awake()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    public void SetUp()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        gameLevelManager.LoadSceneTransition();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitButton()
    {
        gameLevelManager.SaveGameData();
        gameLevelManager.LoadSceneTransition();

        SceneManager.LoadScene("MainMenu");
    }
}
