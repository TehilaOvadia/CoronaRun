using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDetails : MonoBehaviour
{
    LevelManager gameLevelManager;
    SceneTransition endSceneTransition;

    private void Awake()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
        endSceneTransition = FindObjectOfType<SceneTransition>();
    }

    public void HomeButton()
    {
        gameLevelManager.SaveGameData();
        //Scene transition
        endSceneTransition.EndScene();

        SceneManager.LoadScene("MainMenu");
    }
}
