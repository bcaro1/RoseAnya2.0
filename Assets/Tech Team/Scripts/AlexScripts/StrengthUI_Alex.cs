using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthUI_Alex : MonoBehaviour
{
    public GameObject textUI;

    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textUI.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textUI.SetActive(false);
        }
    }
}
