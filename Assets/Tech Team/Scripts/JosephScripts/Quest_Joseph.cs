using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest_Joseph
{
    #region Public
    public string QuestName;
    public string ElementUsed;
    public bool CanBeTurnedIn = false;
    public bool Success = false;
    //Possibly Consider Adding Rewards to Quests
    #endregion

    #region Private
    private Transform StartLocation;
    //Possibly a Reference to Fungus?
    #endregion

    public abstract void InitializeTask();

    public abstract void IncrementTask();

    public abstract void CompleteTask();

    public abstract void RestartOnFail();
}
