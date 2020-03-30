using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleEffects_Alex : MonoBehaviour
{
    #region Public
    [Header("References")]
    [Tooltip("Drag and drop Player's particle effects here")]
    public GameObject[] Fire_Absorb_ParticleEffects; //Array of fire absorb particle effects
    public GameObject[] Water_Absorb_ParticleEffects; //Array of water absorb particle effects
    public GameObject[] Air_Absorb_ParticleEffects; //Array of air absorb particle effects
    public GameObject[] Earth_Absorb_ParticleEffects; //Array of earth absorb particle effects

    [Space]

    public GameObject[] Fire_Discharge_ParticleEffects; //Array of fire discharge particle effects
    public GameObject[] Water_Discharge_ParticleEffects; //Array of water discharge particle effects
    public GameObject[] Air_Discharge_ParticleEffects; //Array of air discharge particle effects
    public GameObject[] Earth_Discharge_ParticleEffects; //Array of earth discharge particle effects
    #endregion

    #region Private
    private Gauges_Alex GaugesScript; // Gauge script
    private GameObject Gauge;
    #endregion

    void Awake()
    {
        // REFERENCES //
        Gauge = GameObject.FindGameObjectWithTag("Gauge"); // Grabs Gauge
        GaugesScript = Gauge.GetComponent<Gauges_Alex>(); // Grabs script on Gauge
    }

    void Update()
    {
        AbsorbEffect();
        DischargeEffect();
    }
    public void AbsorbEffect()
    {
        if (Input.GetButtonDown("Absorb"))
        {
            if (GaugesScript.fireGauge.fillAmount > GaugesScript.currFireFill) // Check if new fill is greater than previous fill
            {
                // for (var i = 0; i < Fire_Absorb_ParticleEffects.length; i++)
                // {
                    
                // }
            }
        }
        if (Input.GetButtonDown("Absorb"))
        {
            if (GaugesScript.waterGauge.fillAmount > GaugesScript.currWaterFill)
            {
                // for (var i = 0; i < Water_Absorb_ParticleEffects.length; i++)
                // {
                    
                // }
            }
        }
        if (Input.GetButtonDown("Absorb"))
        {
            if (GaugesScript.airGauge.fillAmount > GaugesScript.currAirFill)
            {
                // for (var i = 0; i < Air_Absorb_ParticleEffects.length; i++)
                // {
                    
                // }
            }
        }
        if (Input.GetButtonDown("Absorb"))
        {
            if (GaugesScript.earthGauge.fillAmount > GaugesScript.currEarthFill)
            {
                // for (var i = 0; i < Earth_Absorb_ParticleEffects.length; i++)
                // {
                    
                // }
            }
        }
    }

    public void DischargeEffect()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (GaugesScript.fireGauge.fillAmount < GaugesScript.currFireFill)
            {
                // for (var i = 0; i < Fire_Absorb_ParticleEffects.length; i++)
                // {
                    
                // }
            }
        }
        if (Input.GetButtonDown("Interact"))
        {
            if (GaugesScript.waterGauge.fillAmount < GaugesScript.currWaterFill)
            {
                // for (var i = 0; i < Water_Absorb_ParticleEffects.length; i++)
                // {
                    
                // }
            }
        }
        if (Input.GetButtonDown("Interact"))
        {
            if (GaugesScript.airGauge.fillAmount < GaugesScript.currAirFill)
            {
                // for (var i = 0; i < Air_Absorb_ParticleEffects.length; i++)
                // {
                    
                // }
            }
        }
        if (Input.GetButtonDown("Interact"))
        {
            if (GaugesScript.earthGauge.fillAmount < GaugesScript.currEarthFill)
            {
                // for (var i = 0; i < Earth_Absorb_ParticleEffects.length; i++)
                // {
                    
                // }
            }
        }
    }
}
