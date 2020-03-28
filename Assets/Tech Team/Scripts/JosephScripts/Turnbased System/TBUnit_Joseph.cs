using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBUnit_Joseph : MonoBehaviour
{
    public string UnitName;
    public int UnitLevel;
    public int UnitType;
    public int EscapeChance;
    public int EXP;

    public int Damage;
    public int MagicDamage;

    public int MaxHP;
    public int CurrentHP;

    private void Start()
    {
        if(UnitType == -1)
        {
            UnitLevel = StaticDatabase_Joseph.Level;
            Damage = StaticDatabase_Joseph.Attack;
            MagicDamage = StaticDatabase_Joseph.Magic;
            MaxHP = StaticDatabase_Joseph.HP;
            CurrentHP = StaticDatabase_Joseph.CurrentHP;
        }
    }

    public bool TakeDamage(int Damage)
    {
        CurrentHP -= Damage;

        if(CurrentHP <= 0)
        {
            return true;
        }
        return false;
    }
}
