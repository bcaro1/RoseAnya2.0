using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager_Joseph : MonoBehaviour
{
    #region Public
    public ElementController_Joseph ElementController;
    public QuestSystem_Joseph QuestController;
    public SaveData_Joseph Data;
    #endregion

    private void Start()
    {
        if (!Directory.Exists(Application.dataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Saves");
        }
    }

    public void Save()
    {
        //Get Character Name for now this is placeholder
        Data.CharacterName = "Joseph";
        Data.WindUnlocked = ElementController.GetWindUnlocked;
        Data.EarthUnlocked = ElementController.GetEarthUnlocked;
        Data.FireUnlocked = ElementController.GetFireUnlocked;
        Data.WaterAmount = ElementController.Water;
        Data.WindAmount = ElementController.Wind;
        Data.EarthAmount = ElementController.Earth;
        Data.FireAmount = ElementController.Fire;
        Data.QuestNumber = QuestController.GetQuestNumber();


        string FileName = Data.CharacterName + ".json";
        string json = JsonUtility.ToJson(Data);
        WriteToFile(FileName, json);
    }

    public void Load()
    {
        Data = new SaveData_Joseph();
        //Change Filename to whatever the name of the button is when loading
        string json = ReadFromFile("Joseph.json");
        JsonUtility.FromJsonOverwrite(json, Data);
        //Give Character Name to whatever holds it
        ElementController.SetWindUnlocked(Data.WindUnlocked);
        ElementController.SetEarthUnlocked(Data.EarthUnlocked);
        ElementController.SetFireUnlocked(Data.FireUnlocked);
        ElementController.Water = Data.WaterAmount;
        ElementController.Wind = Data.WindAmount;
        ElementController.Earth = Data.EarthAmount;
        ElementController.Fire = Data.FireAmount;
        QuestController.QuestOnLoad(Data.QuestNumber);
        Debug.Log(Data.FireAmount);
    }

    private void WriteToFile(string FilePath, string json)
    {
        string Path = GetFilePath(FilePath);
        Debug.Log(Path);
        var Stream = new FileStream(Path, FileMode.Create);

        using (StreamWriter Writer = new StreamWriter(Stream))
        {
            Writer.Write(json);
        }

        Stream.Close();
    }

    private string ReadFromFile(string FileName)
    {
        string Path = GetFilePath(FileName);
        Debug.Log(Path);
        if (File.Exists(Path))
        {
            using (StreamReader Reader = new StreamReader(Path))
            {
                string json = Reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("No such file exists");
        }
        return "";
    }

    private string GetFilePath(string FileName) => Application.dataPath + "/Saves/" + FileName;
}
