using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManagement_Alex : MonoBehaviour
{
    #region Public
    public bool tutorial, firstQuest, secondQuest, thirdQuest, finalQuest;
    public Image black;
    public Animator animator;
    #endregion
    void Awake()
    {
        
    }
    void Update()
    {
        
    }
    public IEnumerator FadeOut()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(()=>black.color.a ==1);
        StartCoroutine(FadeIn());
    }
    public IEnumerator FadeIn()
    {
        animator.SetBool("Fade", false);
        yield return new WaitUntil(()=>black.color.a ==0);
    }
}
