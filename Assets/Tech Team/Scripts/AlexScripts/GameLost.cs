using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLost : MonoBehaviour
{
    public Image black;
    public Animator animator;
    [Header("Panels")]
    public GameObject LostPanel;
    public GameObject ChoicesPanel;
    void Awake()
    {
        StartCoroutine(GameOver());
    }

    void Update()
    {

    }
    public IEnumerator GameOver()
    {
        StartCoroutine(FadeIn());
        LostPanel.SetActive(true);
        yield return new WaitForSeconds (5.0f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds (2.0f);
        LostPanel.SetActive(false);
        StartCoroutine(Choices());
    }
    public IEnumerator Choices()
    {
        StartCoroutine(FadeIn());
        ChoicesPanel.SetActive(true);  
        yield return new WaitForSeconds(0.0f);
    }
    
    public IEnumerator FadeOut()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(()=>black.color.a ==1);
    }
    public IEnumerator FadeIn()
    {
        animator.SetBool("Fade", false);
        yield return new WaitUntil(()=>black.color.a ==0);
    }
    
}
