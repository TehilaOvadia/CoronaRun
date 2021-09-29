using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    CharacterController2D gamePlayer;
    SceneTransition endSceneTransition;

    public GameOverScreen gameOverScreen;
    public GameObject LevelDetails;
    public Text lifeAmount;

    public float respawnDelay;
    public int healthAmount;
    public int levelNum;
    public bool hasSyringe;

    private void Awake()
    {
        gamePlayer = FindObjectOfType<CharacterController2D>();
        endSceneTransition = FindObjectOfType<SceneTransition>();

        LoadGameData();

        //levelNum = SceneManager.GetActiveScene().buildIndex;

        //Debug.Log("Health: " + healthAmount);
        //Debug.Log("Has syringe: " + hasSyringe);
        //Debug.Log("Level num: " + levelNum);
    }

    //private void Start()
    //{
    //    sceneTransition.SetUp();
    //}

    public void SaveGameData()
    {
        SaveSystem.SaveGameData(this);
    }

    public void LoadGameData()
    {
        GameData data = SaveSystem.LoadGameData();

        healthAmount = data.healthAmount;
        levelNum = data.levelNum;
        hasSyringe = data.hasSyringe;
    }

    private void Update()
    {
        //Check if not at the main menu
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            lifeAmount.text = healthAmount.ToString();
        }
        
    }

    public void GetHarmed()
    {
        StartCoroutine("GetHarmedCoroutine");
    }

    public IEnumerator GetHarmedCoroutine()
    {
        gamePlayer.isHarmed = true;
        yield return new WaitForSeconds(0.7f);
        gamePlayer.isHarmed = false;
        gamePlayer.enemyHasCollide = false;
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.isDead = true;
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.isDead = false;
        gamePlayer.enemyHasCollide = false;
    }

    public void NextLevel()
    {
        StartCoroutine("NextLevelCoroutine");
    }

    public IEnumerator NextLevelCoroutine()
    {
        levelNum += 1;
        SaveGameData();
        gamePlayer.isDoorOpen = true;
        yield return new WaitForSeconds(3f);
        //Scene transition
        endSceneTransition.EndScene();
        SceneManager.LoadScene(levelNum);
    }

    public void GameOver()
    {
        gameOverScreen.SetUp();
        gamePlayer.isDead = true;

        healthAmount = 5;
        SaveGameData();
    }
}
