using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController_Joseph : MonoBehaviour
{
    #region Public
    public GameObject Platform;
    public bool Up;
    public int Distance = 10;
    public PlatformController_Joseph[] Neighbors;
    public bool On = false;
    #endregion

    public void TurnOn()
    {
        if (!On)
        {
            if (Up)
            {
                //Play animation of platform rising
                Platform.transform.position = new Vector3(Platform.transform.position.x, Platform.transform.position.y + Distance, Platform.transform.position.z);
            }
            else
            {
                //Play animation of platform falling
                Platform.transform.position = new Vector3(Platform.transform.position.x, Platform.transform.position.y - Distance, Platform.transform.position.z);
            }
            On = true;
        }
    }

    public void TurnOff()
    {
        if (On)
        {
            if (Up)
            {
                //Play animation of platform falling
                Platform.transform.position = new Vector3(Platform.transform.position.x, Platform.transform.position.y - Distance, Platform.transform.position.z);
            }
            else
            {
                //Play animation of platform rising
                Platform.transform.position = new Vector3(Platform.transform.position.x, Platform.transform.position.y + Distance, Platform.transform.position.z);
            }
            On = false;
        }
    }

    public void ToggleNeighbors()
    {
        for(int i = 0; i < Neighbors.Length; i++)
        {
            if(Neighbors[i].On)
            {
                Neighbors[i].TurnOff();
            }
            else
            {
                Neighbors[i].TurnOn();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Strength"))
        {
            if(On)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }

            ToggleNeighbors();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Strength"))
        {
            if (On)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }

            ToggleNeighbors();
        }
    }
}
