using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus; // access to fungus

public class StoryManagement_Alex : MonoBehaviour
{
    #region Public
    public GameObject Checkpoint, CollectFish, Camera, FishingMinigamePREFAB, HouseFire, FishingMinigame;
    public Flowchart flowchart; // calls the flowchart.
    public GameObject QuestSymbolStart, QuestSymbolBook, QuestSymbolFire;
    #endregion
    #region Private
    private int JimothyQuest, JeanieQuest, LearnQuest, ChickenQuest, HeroQuest;
    private GameObject Player;    
    private PlayerMovement PlayerMovementScript;
    #endregion
    void Awake()
    {
        // REFERENCES //
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovementScript = Player.GetComponent<PlayerMovement>(); // Grabs movement script attached to Player
    }
    void Start()
    {
        JimothyQuest = flowchart.GetIntegerVariable("JimothyQuest");
        JeanieQuest = flowchart.GetIntegerVariable("JeanieQuest");
        LearnQuest = flowchart.GetIntegerVariable("LearnQuest");
        ChickenQuest = flowchart.GetIntegerVariable("ChickenQuest");
        

        QuestSymbolSetup();

        if (JimothyQuest > 0 ) // CHECKPOINT
        {
            Player.transform.position = Checkpoint.transform.position;
            Camera.transform.position = Checkpoint.transform.position;
        }
        if (JimothyQuest == 2 && JeanieQuest == 2 && LearnQuest == 2 && ChickenQuest == 1)
        {
            CollectFish.SetActive(true);
        }
    }
    public void LaunchFishing()
    {
        if (FishingMinigame == null)
        {
            PlayerMovementScript.canMove = false;
            FishingMinigame = Instantiate(FishingMinigamePREFAB);
            FishingMinigame = GameObject.FindGameObjectWithTag("FishingMinigame");
        }
    }
    public void LaunchHouseFire()
    {
        HouseFire.SetActive(true);
    }
    public void QuestSymbolSetup()
    {
        JimothyQuest = flowchart.GetIntegerVariable("JimothyQuest");
        JeanieQuest = flowchart.GetIntegerVariable("JeanieQuest");
        LearnQuest = flowchart.GetIntegerVariable("LearnQuest");
        ChickenQuest = flowchart.GetIntegerVariable("ChickenQuest");
        
        if (JimothyQuest == 0)
        {
            QuestSymbolStart.SetActive(true);
        }   
        if (JimothyQuest == 1)
        {
            QuestSymbolBook.SetActive(true);
        } 
        if (LearnQuest == 1)
        {
            QuestSymbolFire.SetActive(true);
        }
    }
}
