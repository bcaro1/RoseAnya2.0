using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager_Alex : MonoBehaviour
{
    GameObject Player;
    public Image black;
    public Animator animator;
    string currentScene;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //Find Player
        currentScene = SceneManager.GetActiveScene().name; // get active scene build index

        if (currentScene == "MainMenu(Yingying)") // Do this if in Main Menu
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Update()
    {

    }
    public IEnumerator MainMenu()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("MainMenu(Yingying)");
    }
    public IEnumerator MainScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("RoseAnya(new)");
    }
    public IEnumerator BedroomScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("RoseAnyaInterior");
    }
    public IEnumerator ForestScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Forest Level");
    }
    public IEnumerator CaveScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("CaveScene");
    }
    public IEnumerator CastleScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Castle Scene");
    }
    public IEnumerator LoadingScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Loading");
    }
    public IEnumerator GameWon()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("WinScreen");
    }
    public IEnumerator GameLost()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("LoseScreen");
    }
    public void Play()
    {
        StartCoroutine(LoadingScene());
    }
    public void LoadMenu()
    {
        StartCoroutine(MainMenu());
    }
    public void Quit()
    {
        Application.Quit();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainScene")
        {
            StartCoroutine(MainScene());
        }
        if (other.gameObject.tag == "LoadingScene")
        {
            LoadingScene();
        }

    }
}
