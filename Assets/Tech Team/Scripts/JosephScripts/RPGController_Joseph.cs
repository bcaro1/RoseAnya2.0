using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGController_Joseph : MonoBehaviour
{
    #region Public
    public int Level;
    public int HP;
    public int CurrentHP;
    public int Attack;
    public int MagicAttack;
    public int EXP;
    public int EXPToNextLevel;
    #endregion

    void Start()
    {
        Level = StaticDatabase_Joseph.Level;
        HP = StaticDatabase_Joseph.HP;
        CurrentHP = StaticDatabase_Joseph.CurrentHP;
        Attack = StaticDatabase_Joseph.Attack;
        MagicAttack = StaticDatabase_Joseph.Magic;
        EXP = StaticDatabase_Joseph.EXP;

        if(Level == 0)
        {
            Level = 1;
            HP = 20;
            CurrentHP = 20;
            Attack = 15;
            MagicAttack = 15;
            StaticDatabase_Joseph.Level = Level;
            StaticDatabase_Joseph.HP = HP;
            StaticDatabase_Joseph.CurrentHP = CurrentHP;
            StaticDatabase_Joseph.Attack = Attack;
            StaticDatabase_Joseph.Magic = MagicAttack;
        }

        CalculateEXPToNextLevel(Level);
    }

    public bool GetEXP(int experience)
    {
        EXP += experience;

        if(CheckLevelUp())
        {
            return true;
        }
        StaticDatabase_Joseph.EXP = EXP;
        return false;   
    }

    public bool CheckLevelUp()
    {
        if (EXP >= EXPToNextLevel)
        {
            Level++;
            EXP -= EXPToNextLevel;
            CalculateStatChanges();
            CalculateEXPToNextLevel(Level);
            StaticDatabase_Joseph.Level = Level;
            StaticDatabase_Joseph.EXP = EXP;
            return true;
        }
        return false;
    }

    private void CalculateEXPToNextLevel(int Level)
    {
        EXPToNextLevel = Mathf.RoundToInt(0.04f * (Mathf.Pow(Level, 3)) + 0.8f * (Mathf.Pow(Level, 2)) + 2 * Level);
    }

    private void CalculateStatChanges()
    {
        int HPAdd = Random.Range(2, 6);
        int AttackAdd = Random.Range(1, 6);
        int MagicAdd = Random.Range(2, 8);
        HP += HPAdd;
        Attack += AttackAdd;
        MagicAttack += MagicAdd;

        StaticDatabase_Joseph.HP = HP;
        StaticDatabase_Joseph.CurrentHP = HP;
        StaticDatabase_Joseph.Attack = Attack;
        StaticDatabase_Joseph.Magic = MagicAttack;
    }
}
