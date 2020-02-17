using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange_Alex : MonoBehaviour
{
    public Camera camera2;

    void Awake()
    {
    }
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // if the player is out of radius
        {
            camera2.enabled = false;
        }
    }
}
