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
                    Controller.ResetPuzzle();
                }
                else
                {
                    IsOn = true;
                    Controller.CheckWin();
                    Debug.Log("Stepped on");
                }
            }
        }
    }
}
