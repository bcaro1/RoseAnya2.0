using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem_Joseph : MonoBehaviour
{
    #region Public
    public List<Quest_Joseph> QuestList = new List<Quest_Joseph>();
    #endregion

    #region Private
    private int CurrentQuest = 0;
    #endregion

    public int GetQuestNumber() => CurrentQuest;

    public void StartQuest()
    {
        //Checks to see if the Current Quest Exists in the List then Initializes the Quest
        if (QuestList[CurrentQuest] != null)
        {
            QuestList[CurrentQuest].InitializeTask();
        }
    }
    
    public void EndQuest()
    {
        if (QuestList[CurrentQuest].CanBeTurnedIn)
        {
            //Runs the Complete Task Method
            QuestList[CurrentQuest].CompleteTask();
            if (QuestList[CurrentQuest].Success)
            {
                //Award Whatever Reward we have here
                CurrentQuest++;
            }
            else
            {
                //Half Total Element Energy for that Element
                //List of If Statements Searching for Which Element needs to be Halfed
                QuestList[CurrentQuest].RestartOnFail();
            }
        }
        else
        {
            //Run Dialogue Specific to the Quests
        }
    }

    public void QuestOnLoad(int QuestNumber)
    {
        CurrentQuest = QuestNumber;
        StartQuest();
    }

}
