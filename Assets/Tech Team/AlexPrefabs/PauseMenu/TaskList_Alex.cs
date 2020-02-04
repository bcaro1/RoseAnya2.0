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
    int[] tasks;
    public int TASK_WaterQuest, TASK_FireQuest, TASK_StrenghtQuest, TASK_AirQuest, TASK_GoToQuest;
    public Flowchart flowchart; // calls the flowchart.


    // 0 = NOT STARTED
    // 1 = IN PROGESS (APPEARS IN TO DO LIST)
    // 2 = FINISHED (APPEARS IN COMPLETED LIST)

    void Awake()
    {
        TASK_WaterQuest = 0;
        TASK_FireQuest = 0;
        TASK_StrenghtQuest = 0;
        TASK_AirQuest = 0;
        TASK_GoToQuest = 0;
    }
    void Start()
    {

    }


    void Update()
    {

    }

    public void BuildArrays()
    {

        TASK_WaterQuest = flowchart.GetIntegerVariable("WaterQuest");

        tasksText = new string[]{
            "Collect water + fill well",    //0
            "Put out fire",                 //1
            "Move boulder",                 //2
            "Use air",                      //3
            "go to npc",                    //4
        };

        tasks = new int[]{
            TASK_WaterQuest,                //0
            TASK_FireQuest,                 //1
            TASK_StrenghtQuest,             //2
            TASK_AirQuest,                  //3
            TASK_GoToQuest,                 //4
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
