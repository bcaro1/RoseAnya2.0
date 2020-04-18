using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class StaticDatabase_Joseph
{
    public delegate void OnElementValueChanged();
    public static OnElementValueChanged OnElementChangedCallback;

    private static int water, fire, earth, wind, maxmana, currentquest, level, hp, currenthp, attack, magic, exp;

    private static bool unlockedfire = true, unlockedearth = true, unlockedwind = true;

    private static string charactername;

    private static GameObject enemy;

    private static Item_Joseph item;

    private static Sprite background;

    private static List<Item_Joseph> items;

    private static AudioClip bgm;

    public static int Water
    {
        get
        {
            return water;
        }

        set
        {
            water = value;

            if(water > maxmana)
            {
                water = maxmana;
            }

            if(OnElementChangedCallback != null)
            {
                OnElementChangedCallback.Invoke();
            }
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

            if(fire > maxmana)
            {
                fire = maxmana;
            }

            if (OnElementChangedCallback != null)
            {
                OnElementChangedCallback.Invoke();
            }
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

            if(earth > maxmana)
            {
                earth = maxmana;
            }

            if (OnElementChangedCallback != null)
            {
                OnElementChangedCallback.Invoke();
            }
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

            if(wind > maxmana)
            {
                wind = maxmana;
            }

            if (OnElementChangedCallback != null)
            {
                OnElementChangedCallback.Invoke();
            }
        }
    }

    public static int MaxMana
    {
        get
        {
            return maxmana;
        }

        set
        {
            maxmana = value;
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

            if (currenthp > hp)
            {
                currenthp = hp;
            }

            if (OnElementChangedCallback != null)
            {
                OnElementChangedCallback.Invoke();
            }
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

    public static GameObject Enemy
    {
        get
        {
            return enemy;
        }

        set
        {
            enemy = value;
        }
    }

    public static Item_Joseph Item
    {
        get
        {
            return item;
        }

        set
        {
            item = value;
        }
    }

    public static Sprite BackGround
    {
        get
        {
            return background;
        }

        set
        {
            background = value;
        }
    }

    public static List<Item_Joseph> Items
    {
        get
        {
            return items;
        }

        set
        {
            items = value;
        }
    }

    public static AudioClip BGM
    {
        get
        {
            return bgm;
        }

        set
        {
            bgm = value;
        }
    }
}
