using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementController_Joseph : MonoBehaviour
{
    #region Public
    public int Earth = 0;
    public int Wind = 0;
    public int Fire = 0;
    public int Water = 0;
    public Rigidbody Player;
    public int DashForce = 50;
    public float DashDuration = 0.2f;
    public int DashCost = 1;
    public float CoolDownRate = 2f;
    #endregion

    #region Private
    private bool UnlockedEarth = false;
    private bool UnlockedWind = false;
    private bool UnlockedFire = false;
    private int CurrentElement = 0;
    private int MaxElementValue = 16;
    private float CooldownTimer = 0;
    #endregion

    void Start()
    {
        //Here would be checking the save to see what elements are unlocked and the previously held elements
        Water = StaticDatabase_Joseph.Water;
        Wind = StaticDatabase_Joseph.Wind;
        Earth = StaticDatabase_Joseph.Earth;
        Fire = StaticDatabase_Joseph.Fire;
        UnlockedWind = StaticDatabase_Joseph.UnlockedWind;
        UnlockedEarth = StaticDatabase_Joseph.UnlockedEarth;
        UnlockedFire = StaticDatabase_Joseph.UnlockedFire;
    }


    void Update()
    {
        //Checks to See if there is Scroll Wheel Input, and if there is changes the element
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            ToggleElement();
        }
        //Checks to see if Dash is pushed, and if it is dashes
        if(Input.GetButtonDown("Dash"))
        {
            StartCoroutine(Dash());
        }
    }

    void ToggleElement()
    {
        //Scrolls the Element one further in the cycle if not already at the end of the list, if it is at the end of the list it resets back to 0
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(CurrentElement < 3)
            {
                CurrentElement++;
            }
            else
            {
                CurrentElement = 0;
            }
        }
        //Scrolls the Element one back in the cycle if not already at the end of the list, if it is at the end of the list it resets back to 3
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (CurrentElement > 0)
            {
                CurrentElement--;
            }
            else
            {
                CurrentElement = 3;
            }
        }
        
        //Resetting CurrentElement if it trys to use an Element that is not unlocked
        if(CurrentElement == 1 && !UnlockedWind)
        {
            CurrentElement = 0;
        }

        if(CurrentElement == 2 && !UnlockedEarth)
        {
            CurrentElement = 0;
        }

        if(CurrentElement == 3 && !UnlockedFire)
        {
            CurrentElement = 0;
        }
        //Down Here would be where we do any effects/visual notification of what element is currently equipped
    }

    void AbsorbElement(int Value)
    {
        //Checks the Current Element, then Checks to see if the maximum will be exceeded if more element is absorbed
        if (CurrentElement == 0)
        {
            if(Water + Value <= MaxElementValue)
            {
                Water += Value;
            }
        }
        else if (CurrentElement == 1)
        {
            if (Wind + Value <= MaxElementValue)
            {
                Wind += Value;
            }
        }
        else if (CurrentElement == 2)
        {
            if (Earth + Value <= MaxElementValue)
            {
                Earth += Value;
            }
        }
        else if (CurrentElement == 3)
        {
            if (Fire + Value <= MaxElementValue)
            {
                Fire += Value;
            }
        }
        UpdateValues();
    }

    void UseElement(int Value)
    {
        //Checks the Current Element, then Checks to see if the minimum will be exceeded if more element is Given
        if (CurrentElement == 0)
        {
            if (Water - Value >= 0)
            {
                Water -= Value;
            }
        }
        else if (CurrentElement == 1)
        {
            if (Wind - Value >= 0)
            {
                Wind -= Value;
            }
        }
        else if (CurrentElement == 2)
        {
            if (Earth - Value >= 0)
            {
                Earth -= Value;
            }
        }
        else if (CurrentElement == 3)
        {
            if (Fire - Value >= 0)
            {
                Fire -= Value;
            }
        }
        UpdateValues();
    }

    public void UnlockEarth()
    {
        UnlockedEarth = true;
        UpdateValues();
    }

    public void UnlockFire()
    {
        UnlockedFire = true;
        UpdateValues();
    }

    public void UnlockWind()
    {
        UnlockedWind = true;
        UpdateValues();
    }

    IEnumerator Dash()
    {
        //Checks to see if there is Wind available to use for Dashing, and if the Dash is off cooldown
        if (Wind - DashCost >= 0 && CooldownTimer < Time.time)
        {
            //Adds force in the direction teh camera is facing, then waits for the duration to end before resetting velocity
            Player.AddForce(Camera.main.transform.forward * DashForce, ForceMode.VelocityChange);
            yield return new WaitForSeconds(DashDuration);
            Player.velocity = Vector3.zero;
            Wind -= DashCost;
            CooldownTimer = Time.time + CoolDownRate;
        }
        UpdateValues();
    }

    private void OnTriggerStay(Collider other)
    {
        //Gets Reference to Game Object that is being collided with
        GameObject Holder = other.gameObject;
        string Tag = Holder.tag;

        //Checks to make sure the element that is currently selected and the element of the holder are the same
        if(Tag.Equals("Water") && CurrentElement == 0)
        {
            ElementHolder_Joseph CurrentObj = Holder.GetComponent<ElementHolder_Joseph>();
            int ChangeValue = CurrentObj.ValueGiven;
            //Absorbs the Element
            if (Input.GetButtonDown("Absorb"))
            {
                AbsorbElement(ChangeValue);
                CurrentObj.ElementAbsorbed();
            }
            //Gives away the element
            else if(Input.GetButtonDown("Interact"))
            {
                UseElement(ChangeValue);
                CurrentObj.ElementGiven();
            }
            //Display LEvels in some way
        }
        else if(Tag.Equals("Wind") && CurrentElement == 1)
        {
            ElementHolder_Joseph CurrentObj = Holder.GetComponent<ElementHolder_Joseph>();
            int ChangeValue = CurrentObj.ValueGiven;
            if (Input.GetButtonDown("Absorb"))
            {
                AbsorbElement(ChangeValue);
                CurrentObj.ElementAbsorbed();
            }
            else if (Input.GetButtonDown("Interact"))
            {
                UseElement(ChangeValue);
                CurrentObj.ElementGiven();
            }
            //Display LEvels in some way
        }
        else if(Tag.Equals("Earth") && CurrentElement == 2)
        {
            ElementHolder_Joseph CurrentObj = Holder.GetComponent<ElementHolder_Joseph>();
            int ChangeValue = CurrentObj.ValueGiven;
            if (Input.GetButtonDown("Absorb"))
            {
                AbsorbElement(ChangeValue);
                CurrentObj.ElementAbsorbed();
            }
            else if (Input.GetButtonDown("Interact"))
            {
                UseElement(ChangeValue);
                CurrentObj.ElementGiven();
            }
            //Display LEvels in some way
        }
        else if(Tag.Equals("Fire") && CurrentElement == 3)
        {
            ElementHolder_Joseph CurrentObj = Holder.GetComponent<ElementHolder_Joseph>();
            int ChangeValue = CurrentObj.ValueGiven;
            if (Input.GetButtonDown("Absorb"))
            {
                AbsorbElement(ChangeValue);
                CurrentObj.ElementAbsorbed();
            }
            else if (Input.GetButtonDown("Interact"))
            {
                UseElement(ChangeValue);
                CurrentObj.ElementGiven();
            }
            //Display LEvels in some way
        }
    }

    private void UpdateValues()
    {
        StaticDatabase_Joseph.UnlockedWind = UnlockedWind;
        StaticDatabase_Joseph.UnlockedEarth = UnlockedEarth;
        StaticDatabase_Joseph.UnlockedFire = UnlockedFire;
        StaticDatabase_Joseph.Water = Water;
        StaticDatabase_Joseph.Wind = Wind;
        StaticDatabase_Joseph.Earth = Earth;
        StaticDatabase_Joseph.Fire = Fire;
    }

    public bool GetWindUnlocked => UnlockedWind;

    public bool GetEarthUnlocked => UnlockedEarth;

    public bool GetFireUnlocked => UnlockedFire;

    public void SetWindUnlocked(bool Unlocked) => UnlockedWind = Unlocked;

    public void SetEarthUnlocked(bool Unlocked) => UnlockedEarth = Unlocked;

    public void SetFireUnlocked(bool Unlocked) => UnlockedFire = Unlocked;
}
