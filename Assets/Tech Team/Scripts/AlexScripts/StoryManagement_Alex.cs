using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus; // access to fungus

public class StoryManagement_Alex : MonoBehaviour
{
    #region Public
    public GameObject Checkpoint, CollectFish;
    public Flowchart flowchart; // calls the flowchart.
    #endregion
    #region Private
    private int JimothyQuest, JeanieQuest, LearnQuest, ChickenQuest, HeroQuest;
    private GameObject Player;    
    #endregion
    void Awake()
    {
        // REFERENCES //
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        JimothyQuest = flowchart.GetIntegerVariable("JimothyQuest");
        JeanieQuest = flowchart.GetIntegerVariable("JeanieQuest");

        if (JimothyQuest == 2 && JeanieQuest == 1 || JimothyQuest == 2 && JeanieQuest == 2) 
        {
            Player.transform.position = Checkpoint.transform.position;
        }
        if (JimothyQuest == 2 && JeanieQuest == 2 && LearnQuest == 2 && ChickenQuest == 1)
        {
            CollectFish.SetActive(true);
        }
    }
}
