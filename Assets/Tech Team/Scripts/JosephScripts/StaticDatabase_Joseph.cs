using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticDatabase_Joseph
{
    private static int water, fire, earth, wind, currentquest, level, hp, currenthp, attack, magic, exp;

    private static bool unlockedfire, unlockedearth, unlockedwind;

    private static string charactername;

    public static int Water
    {
        get
        {
            return water;
        }

        set
        {
            water = value;
        }
    }

    public static int Fire
    {
        get
        {
            return fire;
        }

        set
        {
            fire = value;
        }
    }

    public static int Earth
    {
        get
        {
            return earth;
        }

        set
        {
            earth = value;
        }
    }

    public static int Wind
    {
        get
        {
            return wind;
        }

        set
        {
            wind = value;
        }
    }

    public static int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public static int HP
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public static int CurrentHP
    {
        get
        {
            return currenthp;
        }

        set
        {
            currenthp = value;
        }
    }

    public static int Attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    public static int Magic
    {
        get
        {
            return magic;
        }

        set
        {
            magic = value;
        }
    }

    public static int EXP
    {
        get
        {
            return exp;
        }

        set
        {
            exp = value;
        }
    }

    public static int CurrentQuest
    {
        get
        {
            return currentquest;
        }

        set
        {
            currentquest = value;
        }
    }

    public static bool UnlockedFire
    {
        get
        {
            return unlockedfire;
        }

        set
        {
            unlockedfire = value;
        }
    }

    public static bool UnlockedEarth
    {
        get
        {
            return unlockedearth;
        }

        set
        {
            unlockedearth = value;
        }
    }

    public static bool UnlockedWind
    {
        get
        {
            return unlockedwind;
        }

        set
        {
            unlockedwind = value;
        }
    }

    public static string CharacterName
    {
        get
        {
            return charactername;
        }

        set
        {
            charactername = value;
        }
    }
}
