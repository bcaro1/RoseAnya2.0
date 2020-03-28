﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gauges_Alex : MonoBehaviour
{
    #region Public
    [Header("References")]
    [Tooltip("Drag and drop gauge images here")]
    public Image fireGauge; // Fire UI
    public Image waterGauge; 
    public Image airGauge; 
    public Image earthGauge;
    [HideInInspector]
    public float currFireFill, currWaterFill, currAirFill, currEarthFill; // Current Element values

    static float fireFill, waterFill, airFill, earthFill; // These store element fills through each scene
    #endregion

    #region Private
    private GameObject element; // Element that's child of Player
    private ElementController_Joseph ElementControllerScript;
    #endregion

    void Awake()
    {
        // REFERENCES //
        element = GameObject.FindGameObjectWithTag("Element"); // Grabs Element
        ElementControllerScript = element.GetComponent<ElementController_Joseph>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Absorb") || Input.GetButtonDown("Interact"))
        {
            UpdateGauges(); // Updates only when player is absorbing / interacting
        }

        fireGauge.fillAmount = fireFill;
        earthGauge.fillAmount = earthFill;
        waterGauge.fillAmount = waterFill;
        airGauge.fillAmount = airFill;

    }

    void UpdateGauges()
    {
        // Converting number to float between 0-1
        fireFill = ElementControllerScript.Fire / 12.0f;
        earthFill = ElementControllerScript.Earth / 12.0f;
        waterFill = ElementControllerScript.Water / 12.0f;
        airFill = ElementControllerScript.Wind / 12.0f;

        // Stores previous fill amount
        // This is used in PlayerParticleEffects_Alex
        currFireFill = fireFill;
        currEarthFill = earthFill;
        currWaterFill = waterFill;
        currAirFill = airFill;
    }


}
