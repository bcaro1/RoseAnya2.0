using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager_Joseph : MonoBehaviour
{
    #region Public
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
        Data.CharacterName = "Player";
        Data.WindUnlocked = StaticDatabase_Joseph.UnlockedWind;
        Data.EarthUnlocked = StaticDatabase_Joseph.UnlockedEarth;
        Data.FireUnlocked = StaticDatabase_Joseph.UnlockedFire;
        Data.WaterAmount = StaticDatabase_Joseph.Water;
        Data.WindAmount = StaticDatabase_Joseph.Wind;
        Data.EarthAmount = StaticDatabase_Joseph.Earth;
        Data.FireAmount = StaticDatabase_Joseph.Fire;
        Data.QuestNumber = StaticDatabase_Joseph.CurrentQuest;
        
        for(int i = 0; i < StaticDatabase_Joseph.Items.Count; i++)
        {
            Data.Items.Add(StaticDatabase_Joseph.Items[i]);
        }

        string FileName = Data.CharacterName + ".json";
        string json = JsonUtility.ToJson(Data);
        WriteToFile(FileName, json);
        PlayerPrefs.SetInt("SaveFile", 1);
    }

    public void Load()
    {
        Data = new SaveData_Joseph();
        //Change Filename to whatever the name of the button is when loading
        string json = ReadFromFile("Player.json");
        JsonUtility.FromJsonOverwrite(json, Data);
        //Give Character Name to whatever holds it
        StaticDatabase_Joseph.CharacterName = Data.CharacterName;
        StaticDatabase_Joseph.UnlockedWind = Data.WindUnlocked;
        StaticDatabase_Joseph.UnlockedEarth = Data.EarthUnlocked;
        StaticDatabase_Joseph.UnlockedFire = Data.FireUnlocked;
        StaticDatabase_Joseph.Water = Data.WaterAmount;
        StaticDatabase_Joseph.Wind = Data.WindAmount;
        StaticDatabase_Joseph.Earth = Data.EarthAmount;
        StaticDatabase_Joseph.Fire = Data.FireAmount;
        StaticDatabase_Joseph.CurrentQuest = Data.QuestNumber;
        StaticDatabase_Joseph.Items = new List<Item_Joseph>();
        for(int i = 0; i < Data.Items.Count; i++)
        {
            StaticDatabase_Joseph.Items.Add(Data.Items[i]);
            Debug.Log(StaticDatabase_Joseph.Items[i].Name);
        }

        SceneManager.LoadScene(4);
    }

    private void WriteToFile(string FilePath, string json)
    {
        string Path = GetFilePath(FilePath);
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
