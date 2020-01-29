using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Quest_Joseph
{
    #region Public
    string QuestName { set; get; }
    string ElementUsed { set; get; }
    bool CanBeTurnedIn { set; get; }
    bool Success { set; get; }
    Transform StartLocation { set; get; }
    //Possibly Consider Adding Rewards to Quests
    #endregion

    void InitializeTask();

    void IncrementTask();

    void CompleteTask();

    void RestartOnFail();
}
