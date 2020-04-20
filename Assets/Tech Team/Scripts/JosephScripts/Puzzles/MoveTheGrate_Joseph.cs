using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheGrate_Joseph : MonoBehaviour
{
    public Puzzle3_Joseph controller;
    public GameObject SoundPlayer;
    public AudioSource GrateOpen;
    private Sounds_Alex SoundsScript;

    void Awake()
    {
        SoundsScript = SoundPlayer.GetComponent<Sounds_Alex>();
    }
    private void Update()
    {
        if(controller.Won)
        {
            PlaySound();
            if(gameObject.transform.position.y < 39)
            {
                // Debug.Log(gameObject.transform.position.y);
                transform.position += Vector3.up * 2 * Time.deltaTime;
            }
        }
    }
    private void PlaySound()
    {
        if (gameObject.transform.position.y < 39)
        {
            if ((!GrateOpen.isPlaying) && (SoundsScript.soundToggle))
            {
                GrateOpen.Play();
            }
        }
    }


}
