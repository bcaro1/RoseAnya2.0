using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus; // access to fungus

public class StoryManagement_Alex : MonoBehaviour
{
    #region Public
    public GameObject Checkpoint;
    #endregion
    #region Private
    private int JimothyQuest, JeanieQuest, LearnQuest, ChickenQuest, HeroQuest;
    private GameObject Player;
    public Flowchart flowchart; // calls the flowchart.
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

        if (JimothyQuest == 2 && JeanieQuest == 1) 
        {
            Player.transform.position = Checkpoint.transform.position;
        }
    }
}
