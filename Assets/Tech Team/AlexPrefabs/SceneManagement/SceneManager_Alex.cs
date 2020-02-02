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
        if (Input.GetKeyDown("t"))
        {
            StartCoroutine(BedroomScene());
        }
    }

    IEnumerator MainScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(()=>black.color.a ==1);
        SceneManager.LoadScene(2);
    }
    IEnumerator BedroomScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(()=>black.color.a ==1);
        SceneManager.LoadScene(2);
    }
    IEnumerator ForestScene()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(()=>black.color.a ==1);
        SceneManager.LoadScene(2);
    }
}
