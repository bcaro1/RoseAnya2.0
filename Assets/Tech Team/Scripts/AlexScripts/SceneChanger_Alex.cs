﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus; // access to fungus

public class SceneChanger_Alex : MonoBehaviour
{
  GameObject SceneManagement;
  SceneManager_Alex SceneManagerScript;
  public Flowchart flowchart; // calls the flowchart.
  private int JimothyQuest;
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
        JimothyQuest = flowchart.GetIntegerVariable("JimothyQuest");
        if (JimothyQuest > 0) { SceneManagerScript.StartCoroutine("ForestScene"); }
      }
    }
    
  }


}
