using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger_Alex : MonoBehaviour
{
  GameObject SceneManagement;
  SceneManager_Alex SceneManagerScript;
  void Awake()
  {
      SceneManagement = GameObject.FindGameObjectWithTag("SceneManager");
      SceneManagerScript = SceneManagement.GetComponent<SceneManager_Alex>();
  }

  void OnTriggerEnter(Collider other) 
  {
    if (this.gameObject.tag == "LoadingScene")
    {
      if (other.CompareTag("Player")) 
      {
        SceneManagerScript.StartCoroutine("LoadingScene");
        Debug.Log("Loading...");
      }
    }
    if (this.gameObject.tag == "BedroomScene")
    {
      if (other.CompareTag("Player")) 
      {
        SceneManagerScript.StartCoroutine("BedroomScene");
      }
    }
    if (this.gameObject.tag == "ForestScene")
    {
      if (other.CompareTag("Player")) 
      {
        SceneManagerScript.StartCoroutine("ForestScene");
      }
    }
    
  }


}
