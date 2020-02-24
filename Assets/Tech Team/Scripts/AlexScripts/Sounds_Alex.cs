using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_Alex : MonoBehaviour
{
    public AudioSource StrengthSound;
    public AudioSource WaterAbsorbSound;
    public AudioSource WaterDisperseSound;

    private GameObject Player;
    private Strength_Alex StrengthScript;
    private Gauges_Alex GaugesScript; // Gauge script
    private GameObject Gauge;
    void Awake()
    {
        // REFERENCES //
        Player = GameObject.FindGameObjectWithTag("Player");
        StrengthScript = Player.GetComponent<Strength_Alex>();
        Gauge = GameObject.FindGameObjectWithTag("Gauge"); // Grabs Gauge
        GaugesScript = Gauge.GetComponent<Gauges_Alex>(); // Grabs script on Gauge
    }

    void Update()
    {
        PlayStrength();
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
            if (GaugesScript.fireGauge.fillAmount > GaugesScript.currFireFill) // Check if new fill is greater than previous fill
            {

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
            if (GaugesScript.fireGauge.fillAmount < GaugesScript.currFireFill)
            {

            }
        }
        if (Input.GetButtonDown("Interact"))
        {
            if (GaugesScript.waterGauge.fillAmount < GaugesScript.currWaterFill)
            {

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
