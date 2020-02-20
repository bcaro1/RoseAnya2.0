using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Floor_Joseph : MonoBehaviour
{
    #region Public
    public Puzzle3_Joseph Controller;
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!Controller.Won)
            {
                Controller.ResetPuzzle();
            }
        }
    }
}
