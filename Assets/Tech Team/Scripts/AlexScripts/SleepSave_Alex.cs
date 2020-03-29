using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SleepSave_Alex : MonoBehaviour
{

    [Tooltip("Script will find Player")]
    public GameObject Player;
    public GameObject textUI;
    public bool inRadius;
    public Image black;
    public Animator animator;
    
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // Grabs Player
    }

    void Update()
    {
        if (inRadius && Input.GetButtonDown("Interact"))
        {
            Debug.Log("Saving");
            StartCoroutine (FadeOut());
        }
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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if the player is in radius
        {
            textUI.SetActive(true);
            inRadius = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // if the player is out of radius
        {
            textUI.SetActive(false);
            inRadius = false;
        }
    }
}
