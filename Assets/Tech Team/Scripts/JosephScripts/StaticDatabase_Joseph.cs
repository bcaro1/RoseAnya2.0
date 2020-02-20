using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticDatabase_Joseph
{
    private static int water, fire, earth, wind, currentquest;

    private static bool unlockedfire, unlockedearth, unlockedwind;

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
}
