using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Animator sceneAnima;
    public Text levelName;
    public Text levelNameIn;
    public Text levelNameShadow;
    public float transitionTime = 1f;

    private int sceneIndex;

    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex == 0)
        {
            levelName.text = "ESCAPE VIRUS";
        } else if(sceneIndex > 0 && sceneIndex < 11)
        {
            levelName.text = "LEVEL " + SceneManager.GetActiveScene().buildIndex.ToString();
            levelNameIn.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
            levelNameShadow.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
        }else if(sceneIndex == 11)
        {
            levelName.text = "COMING SOON...";
        }
    }

    private void Start()
    {
        SetUp();
    }

    public void SetUp()
    {
        gameObject.SetActive(true);
    }

    public void EndScene()
    {
        StartCoroutine("EndSceneCoroutine");
        //Debug.Log("entered");
    }

    IEnumerator EndSceneCoroutine()
    {
        //Debug.Log("start transition");
        sceneAnima.SetTrigger("SceneEnd");
        //Debug.Log("Set the trigger");
        yield return new WaitForSeconds(transitionTime);
        //Debug.Log("end transition");
    }
}
