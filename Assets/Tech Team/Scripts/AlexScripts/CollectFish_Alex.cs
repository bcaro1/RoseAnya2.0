using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectFish_Alex : MonoBehaviour
{
    #region Public
    public GameObject textUI;
    public GameObject ChickenEnemy;
    public GameObject StoryManager;    
    public bool hasFish;
    #endregion

    #region Private
    private StoryManagement_Alex StoryManagementScript;
    #endregion
    void Awake()
    {
        StoryManagementScript = StoryManager.GetComponent<StoryManagement_Alex>(); 
    }

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && (!hasFish)) // if the player is in radius
        {
            textUI.SetActive(true);

            if (Input.GetButtonDown("Interact")) 
            {
                StoryManagementScript.LaunchFishing();
                textUI.SetActive(false);
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
