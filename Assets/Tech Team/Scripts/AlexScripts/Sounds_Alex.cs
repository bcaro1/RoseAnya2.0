using System.Collections;
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
    void Awake()
    {
        // REFERENCES //
        Player = GameObject.FindGameObjectWithTag("Player");
        MovementScript = Player.GetComponent<PlayerMovement>();
        StrengthScript = Player.GetComponent<Strength_Alex>();

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
            // walkSound.Play();
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
    public void AbsorbFire()
    {
        FireAbsorbSound.Play();
    }
    public void DischargeFire()
    {
        FireDisperseSound.Play();
    }
    public void AbsorbWater()
    {
        WaterAbsorbSound.Play();
    }
    public void DischargeWater()
    {
        WaterDisperseSound.Play();
    }
}
