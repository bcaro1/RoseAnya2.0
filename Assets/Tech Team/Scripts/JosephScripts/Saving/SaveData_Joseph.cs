using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData_Joseph
{
    public string CharacterName;

    public bool WindUnlocked;
    public bool EarthUnlocked;
    public bool FireUnlocked;
    public bool Book;

    public int WaterAmount;
    public int WindAmount;
    public int EarthAmount;
    public int FireAmount;
    public int Level;
    public int HP;
    public int CurrentHP;
    public int Attack;
    public int Magic;
    public int Exp;
    public int JimothyQuest;
    public int JeanieQuest;
    public int LearnQuest;
    public int ChickenQuest;
    public int HeroQuest;
    public int HouseFire;

    public int QuestNumber;
    public List<Item_Joseph> Items;
}
