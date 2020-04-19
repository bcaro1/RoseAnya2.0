using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSoundChecker_Alex : MonoBehaviour
{
    #region Public
    public GameObject SoundPlayer;
    #endregion

    #region Private
    private Sounds_Alex SoundsScript;
    #endregion
    void Awake()
    {
        SoundsScript = SoundPlayer.GetComponent<Sounds_Alex>();
    }


    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Fire") && Input.GetButtonDown("Absorb")) // AbsorbFire
        {
            SoundsScript.AbsorbFire();
        }
        if (other.CompareTag("Fire") && Input.GetButtonDown("Interact")) // DischargeFire
        {
            SoundsScript.DischargeFire();
        }
        if (other.CompareTag("Water") && Input.GetButtonDown("Absorb")) // AbsorbFire
        {
            SoundsScript.AbsorbWater();
        }
        if (other.CompareTag("Water") && Input.GetButtonDown("Interact")) // DischargeFire
        {
            SoundsScript.DischargeWater();
        }
    }
}
