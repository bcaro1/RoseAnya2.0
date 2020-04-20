using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveBarrier : MonoBehaviour
{
    public PinpadController_Joseph controller;
    public GameObject SoundPlayer;
    public AudioSource GrateOpen;
    private Sounds_Alex SoundsScript;
    private bool doOnce;

    void Awake()
    {
        SoundsScript = SoundPlayer.GetComponent<Sounds_Alex>();
        doOnce = false;
    }

    private void Update()
    {
        if(controller.Won)
        {
            PlaySound();
            if(gameObject.transform.position.y < 70)
            {
                // Debug.Log(gameObject.transform.position.y);
                transform.position += Vector3.up * 2 * Time.deltaTime;
            }
        }
    }
    private void PlaySound()
    {
        if (!doOnce)
        {
            if ((!GrateOpen.isPlaying) && (SoundsScript.soundToggle))
            {
                GrateOpen.Play();
                doOnce = true;
            }
        }
    }
}
