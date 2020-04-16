using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus; // access to fungus

public class TaskList_Alex : MonoBehaviour
{
    string[] tasksText; //Text for the tasks
    public Text[] CtextBoxes; //Completed - Text UI
    public Text[] IPtextBoxes; //In Progress - Text UI
    public GameObject CompletedText; //Completed text
    int[] tasks;
    public int TASK_JimothyQuest, TASK_JeanieQuest, TASK_LearnQuest, TASK_ChickenQuest, TASK_HeroQuest;
    public Flowchart flowchart; // calls the flowchart.


    /////***  IMPORTANT ***/////
    // 0 = NOT STARTED
    // 1 = IN PROGESS (APPEARS IN TO DO LIST)
    // 2 = FINISHED (APPEARS IN COMPLETED LIST)

    void Awake()
    {
        TASK_JimothyQuest = 0;
        TASK_JeanieQuest = 0;
        TASK_LearnQuest = 0;
        TASK_ChickenQuest = 0;
        TASK_HeroQuest = 0;

        CompletedText.SetActive(false);
    }
    void Start()
    {

    }


    void Update()
    {

    }

    public void BuildArrays() // Being called in pause menu UI
    {

        TASK_JimothyQuest = flowchart.GetIntegerVariable("JimothyQuest");
        TASK_JeanieQuest = flowchart.GetIntegerVariable("JeanieQuest");
        TASK_LearnQuest = flowchart.GetIntegerVariable("LearnQuest");
        TASK_ChickenQuest = flowchart.GetIntegerVariable("ChickenQuest");
        TASK_HeroQuest = flowchart.GetIntegerVariable("HeroQuest");

        tasksText = new string[]{
            "Find Jimothy",                 //0
            "Locate Jeanie",                //1
            "Learn about Hero",             //2
            "Feed the Chicken",             //3
            "Free the Hero"                 //4
        };

        tasks = new int[]{
            TASK_JimothyQuest,              //0
            TASK_JeanieQuest,               //1
            TASK_LearnQuest,                //2
            TASK_ChickenQuest,              //3
            TASK_HeroQuest                  //4
        };
    }
    public void BuildTaskList()
    {
        // Clear Completed list
        for (var i = 0; i < CtextBoxes.Length; i++)
        {
            CtextBoxes[i].text = ""; 
        }
        // Clear In Progress list
        for (var i = 0; i < IPtextBoxes.Length; i++)
        {
            IPtextBoxes[i].text = ""; 
        }


        // Populate Completed list
        for (var i = 0; i < tasks.Length; i++)
        {
            if (tasks[i] == 2)
            {
                CompletedText.SetActive(true); // Show Completed list only if there's completed tasks

                for (var j = 0; j < CtextBoxes.Length; j++)
                {
                    if (CtextBoxes[j].text == "")
                    {
                        CtextBoxes[j].text = tasksText[i];
                        break;
                    } 
                }
            }
        }
        // Populate In Progress list
        for (var i = 0; i < tasks.Length; i++)
        {
            if (tasks[i] == 1)
            {
                for (var j = 0; j < IPtextBoxes.Length; j++)
                {
                    if (IPtextBoxes[j].text == "")
                    {
                        IPtextBoxes[j].text = tasksText[i];
                        break;
                    } 
                }
            }
        }
    }



}
