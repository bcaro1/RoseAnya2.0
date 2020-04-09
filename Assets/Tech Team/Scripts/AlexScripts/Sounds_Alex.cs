﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_Alex : MonoBehaviour
{
    public AudioSource walkSound; //This is the sound for walking
    public AudioSource StrengthSound;
    public AudioSource WaterAbsorbSound;
    public AudioSource WaterDisperseSound;
    public AudioSource FireAbsorbSound;
    public AudioSource FireDisperseSound;
    public bool soundToggle;

    private GameObject Player;
    private PlayerMovement MovementScript;
    private Strength_Alex StrengthScript;
    private Gauges_Alex GaugesScript; // Gauge script
    private GameObject Gauge;
    void Awake()
    {
        // REFERENCES //
        Player = GameObject.FindGameObjectWithTag("Player");
        MovementScript = Player.GetComponent<PlayerMovement>();
        StrengthScript = Player.GetComponent<Strength_Alex>();
        Gauge = GameObject.FindGameObjectWithTag("Gauge"); // Grabs Gauge
        GaugesScript = Gauge.GetComponent<Gauges_Alex>(); // Grabs script on Gauge

        // VARIABLES //
        soundToggle = true;
    }

    void Update()
    {
        if (soundToggle)
        {
            PlayStrength();
            PlayWalking(); 
        }
    }
    void PlayWalking()
    {
        if ((!walkSound.isPlaying) && (MovementScript.isWalking))
        {
            walkSound.Play();
        }
        else { walkSound.Pause(); }
    }
    void PlayStrength()
    {
        if (!StrengthSound.isPlaying && StrengthScript.CurrentlyUsingStrength)
        {
            StrengthSound.Play();
        }
        else
        {
            StrengthSound.Pause();
        }
    }
    public void AbsorbSounds()
    {
        if (Input.GetButtonDown("Absorb"))
        {
            if ((!FireAbsorbSound.isPlaying) && GaugesScript.fireGauge.fillAmount > GaugesScript.currFireFill) // Check if new fill is greater than previous fill
            {
                FireAbsorbSound.Play();
            }
            else 
            {
                FireAbsorbSound.Pause();
            }
        }
        if (Input.GetButtonDown("Absorb"))
        {
            if ((!WaterAbsorbSound.isPlaying) && GaugesScript.waterGauge.fillAmount > GaugesScript.currWaterFill)
            {
                WaterAbsorbSound.Play();
            }
            else 
            {
                WaterAbsorbSound.Pause();
            }
        }
        if (Input.GetButtonDown("Absorb"))
        {
            if (GaugesScript.airGauge.fillAmount > GaugesScript.currAirFill)
            {

            }
        }
        if (Input.GetButtonDown("Absorb"))
        {
            if (GaugesScript.earthGauge.fillAmount > GaugesScript.currEarthFill)
            {

            }
        }
    }
    public void DischargeSounds()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if ((!WaterDisperseSound.isPlaying) && GaugesScript.fireGauge.fillAmount < GaugesScript.currFireFill)
            {
                FireDisperseSound.Play();
            }
            else
            {
                FireDisperseSound.Pause();
            }
        }
        if (Input.GetButtonDown("Interact"))
        {
            if ((!WaterDisperseSound.isPlaying) && GaugesScript.waterGauge.fillAmount < GaugesScript.currWaterFill)
            {
                WaterDisperseSound.Play();
            }
            else
            {
                WaterDisperseSound.Pause();
            }
        }
        if (Input.GetButtonDown("Interact"))
        {
            if (GaugesScript.airGauge.fillAmount < GaugesScript.currAirFill)
            {

            }
        }
        if (Input.GetButtonDown("Interact"))
        {
            if (GaugesScript.earthGauge.fillAmount < GaugesScript.currEarthFill)
            {

            }
        }
    }

}
