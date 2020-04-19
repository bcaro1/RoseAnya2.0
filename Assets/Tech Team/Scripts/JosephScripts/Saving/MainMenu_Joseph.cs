using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_Joseph : MonoBehaviour
{
    #region Public
    public Button LoadButton;
    public DataManager_Joseph Manager;
    #endregion

    void Start()
    {
        string DataPath = Application.dataPath + "/Saves/Player.json";
        LoadButton.interactable = File.Exists(DataPath);
    }

    public void Load()
    {
        Manager.Load();
    }
}
