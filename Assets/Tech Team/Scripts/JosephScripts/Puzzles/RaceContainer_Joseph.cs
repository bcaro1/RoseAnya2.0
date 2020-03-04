using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceContainer_Joseph : MonoBehaviour, ElementHolder_Joseph
{
    #region Public
    public int CurrentValue { get; set; }
    public int MaxValue { get; set; }
    public int MinValue { get; set; }
    public int ElementUsed { get; set; }
    public int ValueGiven { get; set; }
    #endregion

    public RaceContainer_Joseph()
    {
        ElementUsed = 0;
        MaxValue = 20;
        MinValue = 4;
        CurrentValue = MaxValue;
        ValueGiven = 2;
    }

    public void ElementAbsorbed()
    {
        //Checks to see if the minimum value will be reached by subtracting more element
        if(CurrentValue - ValueGiven >= MinValue)
        {
            //Subtracts the set value from the current value, shrinks the block and moves it down so that it doesn't float
            CurrentValue -= ValueGiven;
            transform.position = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
        }
        else
        {
            //Error Message Here
        }
    }

    public void ElementGiven()
    {
        //Checks to see if the maximum value will be reached/exceeded by adding more element
        if(CurrentValue + ValueGiven <= MaxValue)
        {
            //Adds the set value to the current value, grows the block and moves it upward so it doesn't collide with the ground
            CurrentValue += ValueGiven;
            transform.position = new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z);
        }
        else
        {
            //Error Message Here
        }
    }
}
