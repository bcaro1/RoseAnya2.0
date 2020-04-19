using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveBarrier : MonoBehaviour
{
    public PinpadController_Joseph controller;

    private void Update()
    {
        if(controller.Won)
        {
            if(gameObject.transform.position.y < 39)
            {
                // Debug.Log(gameObject.transform.position.y);
                transform.position += Vector3.up * 2 * Time.deltaTime;
            }
        }
    }


}
