using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Tile_Joseph : MonoBehaviour
{
    #region Public
    public bool IsOn;
    public Puzzle3_Joseph Controller;
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (!Controller.Won)
            {
                if (IsOn)
                {
                    Debug.Log("Reset");
                    Controller.ResetPuzzle();
                }
                else
                {
                    IsOn = true;
                    Debug.Log("Stepped on");
                    Controller.CheckWin();
                }
            }
        }
    }
}
