using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinpadTile_Joseph : MonoBehaviour
{
    public int number;
    public bool isOn = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Strength"))
        {
            isOn = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Strength"))
        {
            isOn = false;
        }
    }
}
