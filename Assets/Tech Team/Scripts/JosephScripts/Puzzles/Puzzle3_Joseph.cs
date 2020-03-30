using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3_Joseph : MonoBehaviour
{
    #region Public
    public Puzzle3Tile_Joseph[] PuzzleTiles;
    public bool Won;
    #endregion

    #region Private
    private int Tiles;
    #endregion

    void Start()
    {
        Tiles = PuzzleTiles.Length;
    }

    public void ResetPuzzle()
    {
        for(int i = 0; i < Tiles; i++)
        {
            PuzzleTiles[i].IsOn = false;
            PuzzleTiles[i].renderer.material = PuzzleTiles[i].offMat;
        }
    }

    public void CheckWin()
    {
        bool Win = true;

        for (int i = 0; i < Tiles; i++)
        {
            if(!PuzzleTiles[i].IsOn)
            {
                Win = false;
                break;
            }
        }

        if(Win)
        {
            Won = Win;
        }
    }
}
