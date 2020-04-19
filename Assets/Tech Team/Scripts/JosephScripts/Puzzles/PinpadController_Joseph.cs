using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinpadController_Joseph : MonoBehaviour
{
    public PinpadTile_Joseph[] tiles;
    public bool Won;

    private bool[] Combination = new bool[4];

    private void Update()
    {
        if (!Won)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i].isOn)
                {
                    if (tiles[i].number == 1 || tiles[i].number == 2 || tiles[i].number == 3 || tiles[i].number == 4)
                    {
                        Combination[tiles[i].number - 1] = true;
                    }
                }
            }
        }

        if(Combination[0] && Combination[1] && Combination[2] && Combination[3])
        {
            Won = true;
        }
    }
}
