using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager_Alex : MonoBehaviour
{
    GameObject Player;
    public GameObject Gauge;
    public Image black;
    public Animator animator;
    int currentScene;
    private Gauges_Alex GaugesScript;
    
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //Find Player
        currentScene = SceneManager.GetActiveScene().buildIndex; // get active scene build index
        GaugesScript = Gauge.GetComponent<Gauges_Alex>();
    }

    void Update()
    {
        if (currentScene == 5) // This is temporary..will change @AH
        {
            FinishTutorial();
        }
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
    public void FinishTutorial()
    {
        if(GaugesScript.waterGauge.fillAmount == 1f)
        {
            StartCoroutine(LoadingScene());
        }
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
