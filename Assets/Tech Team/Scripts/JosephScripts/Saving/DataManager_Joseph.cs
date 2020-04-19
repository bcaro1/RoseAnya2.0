using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class DataManager_Joseph : MonoBehaviour
{
    #region Public
    public SaveData_Joseph Data;
    public Flowchart Chart;
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
        Data.Level = StaticDatabase_Joseph.Level;
        Data.HP = StaticDatabase_Joseph.HP;
        Data.CurrentHP = StaticDatabase_Joseph.CurrentHP;
        Data.Attack = StaticDatabase_Joseph.Attack;
        Data.Magic = StaticDatabase_Joseph.Magic;
        Data.Exp = StaticDatabase_Joseph.EXP;
        Data.JimothyQuest = Chart.GetIntegerVariable("JimothyQuest");
        Data.JeanieQuest = Chart.GetIntegerVariable("JeanieQuest");
        Data.LearnQuest = Chart.GetIntegerVariable("LearnQuest");
        Data.ChickenQuest = Chart.GetIntegerVariable("ChickenQuest");
        Data.HeroQuest = Chart.GetIntegerVariable("HeroQuest");
        Data.HouseFire = Chart.GetIntegerVariable("HouseFire");
        
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
        StaticDatabase_Joseph.Level = Data.Level;
        StaticDatabase_Joseph.HP = Data.HP;
        StaticDatabase_Joseph.CurrentHP = Data.CurrentHP;
        StaticDatabase_Joseph.Attack = Data.Attack;
        StaticDatabase_Joseph.Magic = Data.Magic;
        StaticDatabase_Joseph.EXP = Data.Exp;
        Chart.SetIntegerVariable("JimothyQuest", Data.JimothyQuest);
        Chart.SetIntegerVariable("JeanieQuest", Data.JeanieQuest);
        Chart.SetIntegerVariable("LearnQuest", Data.LearnQuest);
        Chart.SetIntegerVariable("ChickenQuest", Data.ChickenQuest);
        Chart.SetIntegerVariable("HeroQuest", Data.HeroQuest);
        Chart.SetIntegerVariable("HouseFire", Data.HouseFire);

        StaticDatabase_Joseph.Items = new List<Item_Joseph>();
        for(int i = 0; i < Data.Items.Count; i++)
        {
            StaticDatabase_Joseph.Items.Add(Data.Items[i]);
        }

        SceneManager.LoadScene(1);
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
