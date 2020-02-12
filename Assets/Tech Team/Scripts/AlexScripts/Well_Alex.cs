using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; // must be used. This allows the script to access the fungus scripts.

public class Well_Alex : MonoBehaviour, ElementHolder_Joseph
{
    #region Public
    public int CurrentValue { get; set; }
    public int MaxValue { get; set; }
    public int MinValue { get; set; }
    public int ElementUsed { get; set; }
    public int ValueGiven { get; set; }
    [Header("References")]
    [Tooltip("Drag and drop Flowchart here")]
    public Flowchart flowchart;
    #endregion

    public Well_Alex()
    {
        ElementUsed = 0;
        MaxValue = 20;
        MinValue = 4;
        CurrentValue = MinValue;
        ValueGiven = 2;
    }

    public void ElementAbsorbed()
    {
        //Checks to see if the minimum value will be reached by subtracting more element
        if(CurrentValue - ValueGiven >= MinValue)
        {
            //Subtracts the set value from the current value, shrinks the block and moves it down so that it doesn't float
            CurrentValue -= ValueGiven;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - .1f, transform.localScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z);
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
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + .1f, transform.localScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
        }
        else
        {
            //Error Message Here
        }

        if (CurrentValue == MaxValue)
        {
            Debug.Log("Passed Quest!");
            flowchart.SetIntegerVariable("WaterQuest", 2);
        }
    }
}
