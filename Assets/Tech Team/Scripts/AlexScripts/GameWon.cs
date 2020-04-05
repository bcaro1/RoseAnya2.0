using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWon : MonoBehaviour
{
    public Image black;
    public Animator animator;
    [Header("Panels")]
    public GameObject TitlePanel;
    public GameObject ThanksPanel;
    public GameObject Credits1Panel;
    public GameObject Credits2Panel;
    public GameObject Credits3Panel;
    void Awake()
    {
        StartCoroutine(Title());
    }

    void Update()
    {

    }
    public IEnumerator Title()
    {
        StartCoroutine(FadeIn());
        TitlePanel.SetActive(true);
        yield return new WaitForSeconds (5.0f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds (2.0f);
        TitlePanel.SetActive(false);
        StartCoroutine(Thanks());
    }
    public IEnumerator Thanks()
    {
        ThanksPanel.SetActive(true);
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds (5.0f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds (2.0f);
        ThanksPanel.SetActive(false);
        StartCoroutine(Credits1());
    }
    public IEnumerator Credits1()
    {
        Credits1Panel.SetActive(true);
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds (5.0f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds (2.0f);
        Credits1Panel.SetActive(false);
        StartCoroutine(Credits2());
    }
    public IEnumerator Credits2()
    {
        Credits2Panel.SetActive(true);
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds (5.0f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds (2.0f);
        Credits2Panel.SetActive(false);
        StartCoroutine(Credits3());
    }
    public IEnumerator Credits3()
    {
        Credits3Panel.SetActive(true);
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds (5.0f);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds (2.0f);
        Credits3Panel.SetActive(false);
        // StartCoroutine(Credits2());
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
