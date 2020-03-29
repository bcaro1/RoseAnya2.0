using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectFish_Alex : MonoBehaviour
{
    #region Public
    public GameObject textUI;
    public bool hasFish;
    #endregion

    #region Private

    #endregion


    
    void Awake()
    {

    }

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) // if the player is in radius
        {
            textUI.SetActive(true);

            if (Input.GetButtonDown("Interact")) 
            {
                hasFish = true;
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
