using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus; // access to fungus
using UnityEngine.UI;

public class SceneChanger_Alex : MonoBehaviour
{
  #region Public
  public Flowchart flowchart; // calls the flowchart.
  public GameObject TravelMenuUI;
  public GameObject TravelMenuUI_CaveButton;
  public GameObject TravelMenuUI_CastleButton;
  #endregion

  #region Private
  private GameObject SceneManagement;
  private SceneManager_Alex SceneManagerScript;
  private int JimothyQuest, JeanieQuest, LearnQuest, ChickenQuest, HeroQuest;
  #endregion
  
  void Awake()
  {
      // REFERENCES //
      SceneManagement = GameObject.FindGameObjectWithTag("SceneManager");
      SceneManagerScript = SceneManagement.GetComponent<SceneManager_Alex>();
  }

  public void LoadingScene()
  {
    SceneManagerScript.StartCoroutine("LoadingScene");
    Debug.Log("Loading...");
  }
  public void BedroomScene()
  {
    SceneManagerScript.StartCoroutine("BedroomScene");  
  }
  public void ForestScene()
  {
    SceneManagerScript.StartCoroutine("ForestScene");
  }
  public void VillageScene()
  {
    SceneManagerScript.StartCoroutine("MainScene");
  }
  public void CaveScene()
  {
    SceneManagerScript.StartCoroutine("CaveScene");
  }
  public void CastleScene()
  {
    SceneManagerScript.StartCoroutine("Castle Scene");
  }
  public void LoadTravelMenu()
  {
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;

    JimothyQuest = flowchart.GetIntegerVariable("JimothyQuest");
    JeanieQuest = flowchart.GetIntegerVariable("JeanieQuest");
    LearnQuest = flowchart.GetIntegerVariable("LearnQuest");
    ChickenQuest = flowchart.GetIntegerVariable("ChickenQuest");
    HeroQuest = flowchart.GetIntegerVariable("HeroQuest");
    
    if (JimothyQuest > 0) { TravelMenuUI.SetActive(true); }
    if (JeanieQuest > 0) { TravelMenuUI_CaveButton.SetActive(true); }
    if (HeroQuest > 0) { TravelMenuUI_CastleButton.SetActive(true); }
  }
  public void Resume()
  {
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
    TravelMenuUI.SetActive(false);
  }

  void OnTriggerStay(Collider other) 
  {
    if (this.gameObject.tag == "LoadingScene")
    {
      if (other.CompareTag("Player")) 
      {
        LoadingScene();
      }
    }
    if (this.gameObject.tag == "BedroomScene")
    {
      if (other.CompareTag("Player")) 
      {
        BedroomScene();
      }
    }
    if (this.gameObject.tag == "MainScene")
    {
      if (other.CompareTag("Player")) 
      {
        VillageScene();
      }
    }
    if (this.gameObject.tag == "TravelMenu")
    {
      if (other.CompareTag("Player") && Input.GetButtonDown("Interact")) 
      {
        LoadTravelMenu();
      }
    }
    
  }


}
