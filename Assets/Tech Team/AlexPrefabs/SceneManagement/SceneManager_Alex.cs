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
    
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //Find Player
    }

    void Update()
    {
        // if (Input.GetKeyDown("t"))
        // {
            // StartCoroutine(BedroomScene());
        // }
    }

    public IEnumerator MainScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(()=>black.color.a ==1);
        SceneManager.LoadScene(4);
    }
    public IEnumerator BedroomScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(()=>black.color.a ==1);
        SceneManager.LoadScene(2);
    }
    public IEnumerator ForestScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(()=>black.color.a ==1);
        SceneManager.LoadScene(5);
    }
    public IEnumerator LoadingScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(()=>black.color.a ==1);
        SceneManager.LoadScene(3);
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
