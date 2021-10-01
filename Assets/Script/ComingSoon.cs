using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComingSoon : MonoBehaviour
{
    public Animator animator;
    SceneTransition endSceneTransition;

    private void Awake()
    {
        endSceneTransition = FindObjectOfType<SceneTransition>();
    }

    private void Start()
    {
        PlayAnim();
    }

    public void PlayAnim()
    {
        StartCoroutine("PlayAnimCoroutine");
    }

    public IEnumerator PlayAnimCoroutine()
    {
        yield return new WaitForSeconds(5f);
        animator.SetBool("IsDoorOpen", true);
    }

    public void MainMenuButton()
    {
        //Scene transition
        endSceneTransition.EndScene();

        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        //Scene transition
        endSceneTransition.EndScene();

        Application.Quit();
    }
}
