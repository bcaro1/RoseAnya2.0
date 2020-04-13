using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData_Joseph
{
    public string CharacterName;

    public bool WindUnlocked;
    public bool EarthUnlocked;
    public bool FireUnlocked;

    public int WaterAmount;
    public int WindAmount;
    public int EarthAmount;
    public int FireAmount;

    public int QuestNumber;
    public List<Item_Joseph> Items;
}
