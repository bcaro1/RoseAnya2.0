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
    public AudioSource WindSound;
    public GameObject ParticleManager;
    public GameObject Element;
    public bool soundToggle;

    private GameObject Player;
    private PlayerMovement MovementScript;
    private Strength_Alex StrengthScript;
    private ParticleManager ParticleManagerScript;
    private ElementController_Joseph ElementControllerScript;
    void Awake()
    {
        // REFERENCES //
        Player = GameObject.FindGameObjectWithTag("Player");
        MovementScript = Player.GetComponent<PlayerMovement>();
        StrengthScript = Player.GetComponent<Strength_Alex>();
        ParticleManagerScript = ParticleManager.GetComponent<ParticleManager>();
        ElementControllerScript = Element.GetComponent<ElementController_Joseph>();

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
        if (ElementControllerScript.CurrentElement == 3)
        {
            if (soundToggle)
            {
                if (!FireAbsorbSound.isPlaying) 
                { 
                    FireAbsorbSound.Play(); 
                    ParticleManager.SetActive(true);  
                }
            }
            ParticleManagerScript.FireParticle();
        }
    }
    public void DischargeFire()
    {
        if (ElementControllerScript.CurrentElement == 3)
        {
            if (soundToggle)
            {
                if (!FireDisperseSound.isPlaying) 
                { 
                    FireDisperseSound.Play(); 
                    ParticleManager.SetActive(true); 
                }
            }
            ParticleManagerScript.FireParticle(); 
        }
    }
    public void AbsorbWater()
    {
        if (ElementControllerScript.CurrentElement == 0)
        {
            if (soundToggle)
            {
                if (!WaterAbsorbSound.isPlaying) 
                { 
                    WaterAbsorbSound.Play(); 
                    ParticleManager.SetActive(true); 
                }
            }
            ParticleManagerScript.WaterParticle(); 
        }
    }
    public void DischargeWater()
    {
        if (ElementControllerScript.CurrentElement == 0)
        {
            if (soundToggle)
            {
                if (!WaterDisperseSound.isPlaying) 
                { 
                    WaterDisperseSound.Play(); 
                    ParticleManager.SetActive(true);                 
                }
            }
            ParticleManagerScript.WaterParticle(); 
        }
    }
    public void AbsorbDischargeWind()
    {
        if (ElementControllerScript.CurrentElement == 1)
        {
            if (soundToggle)
            {
                if (!WindSound.isPlaying) 
                { 
                    WindSound.Play(); 
                    ParticleManager.SetActive(true); 
                }
            }
            ParticleManagerScript.WindParticle(); 
        }
    }
    public void AbsorbDischargeEarth()
    {
        if (ElementControllerScript.CurrentElement == 2)
        {
            if (soundToggle)
            {
                if (!StrengthSound.isPlaying) 
                { 
                    StrengthSound.Play(); 
                    ParticleManager.SetActive(true); 
                }
            }
            ParticleManagerScript.EarthParticle();
        } 
    }
}
