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
    public GameObject SoundPlayer;
    #endregion

    #region Private
    private Sounds_Alex SoundsScript;
    #endregion
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        SoundsScript = SoundPlayer.GetComponent<Sounds_Alex>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (!Controller.Won)
            {
                if (IsOn)
                {                    
                    renderer.material = offMat;
                    Controller.ResetPuzzle();
                }
                else
                {
                    IsOn = true;                    
                    renderer.material = onMat;
                    SoundsScript.PlayTileSound();
                    Controller.CheckWin();
                }
            }
        }
    }
}
