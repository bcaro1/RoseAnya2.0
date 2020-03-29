using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus; // access to fungus

public class FeedChicken_Alex : MonoBehaviour
{
    #region Public
    public GameObject textUI;
    public GameObject CollectFish;
    public Flowchart flowchart; // calls the flowchart.
    #endregion

    #region Private
    private CollectFish_Alex CollectFishScript;
    #endregion
    void Awake()
    {
        // REFERENCES //
        CollectFishScript = CollectFish.GetComponent<CollectFish_Alex>();
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // if the player is in radius
        {
            if (CollectFishScript.hasFish)
            {
                textUI.SetActive(true);

                if (Input.GetButtonDown("Interact")) 
                {
                    textUI.SetActive(false);
                    CollectFishScript.hasFish = false;
                    flowchart.SetIntegerVariable("ChickenQuest", 2);
                    flowchart.SetIntegerVariable("HeroQuest", 1);
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // if the player is out of radius
        {
            textUI.SetActive(false);
        }
    }
}
