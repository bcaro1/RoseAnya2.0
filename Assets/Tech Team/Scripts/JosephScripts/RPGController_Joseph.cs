using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGController_Joseph : MonoBehaviour
{
    #region Public
    public int Level;
    public int HP;
    public int Attack;
    public int MagicAttack;
    public int EXP;
    public int EXPToNextLevel;
    #endregion

    void Start()
    {
        Level = StaticDatabase_Joseph.Level;
        HP = StaticDatabase_Joseph.HP;
        Attack = StaticDatabase_Joseph.Attack;
        MagicAttack = StaticDatabase_Joseph.Magic;
        EXP = StaticDatabase_Joseph.EXP;
        CalculateEXPToNextLevel(Level);
    }

    public bool GetEXP(int experience)
    {
        EXP += experience;

        if(EXP >= EXPToNextLevel)
        {
            Level++;
            EXP -= EXPToNextLevel;

            StaticDatabase_Joseph.Level = Level;
            StaticDatabase_Joseph.EXP = EXP;
            return true;
        }
        StaticDatabase_Joseph.EXP = EXP;
        return false;   
    }

    private void CalculateEXPToNextLevel(int Level)
    {
        EXPToNextLevel = Mathf.RoundToInt(0.04f * (Mathf.Pow(Level, 3)) + 0.8f * (Mathf.Pow(Level, 2)) + 2 * Level);
    }

    private void CalculateStatChanges()
    {
        int HPAdd = Random.Range(1, 6);
        int AttackAdd = Random.Range(1, 6);
        int MagicAdd = Random.Range(2, 8);
        HP += HPAdd;
        Attack += AttackAdd;
        MagicAttack += MagicAdd;

        StaticDatabase_Joseph.HP = HP;
        StaticDatabase_Joseph.Attack = Attack;
        StaticDatabase_Joseph.Magic = MagicAttack;
    }
}
