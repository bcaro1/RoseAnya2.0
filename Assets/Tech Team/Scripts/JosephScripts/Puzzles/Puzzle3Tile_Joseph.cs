using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Tile_Joseph : MonoBehaviour
{
    #region Public
    public bool IsOn;
    public Puzzle3_Joseph Controller;
    public Material offMat;
    public Material onMat;
    public Renderer renderer;
    #endregion

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (!Controller.Won)
            {
                if (IsOn)
                {
                    Debug.Log("Reset");
                    renderer.material = offMat;
                    Controller.ResetPuzzle();
                }
                else
                {
                    IsOn = true;
                    Debug.Log("Stepped on");
                    renderer.material = onMat;
                    Controller.CheckWin();
                }
            }
        }
    }
}
