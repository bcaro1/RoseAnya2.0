using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gauges_Alex : MonoBehaviour
{
    public Image fireGauge;
    public Image waterGauge; 
    public Image airGauge; 
    public Image earthGauge;  

    static float fireFill;
    static float waterFill;
    static float airFill;
    static float earthFill;


    public GameObject element;
    private ElementController_Joseph ElementControllerScript;
    void Start()
    {
        ElementControllerScript = element.GetComponent<ElementController_Joseph>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Absorb") || Input.GetButtonDown("Interact")) //THIS WILL CHANGE TO WHATEVER KEY WE USE TO ABSORB / DISCHARGE ELEMENTS
        {
            UpdateGauges();
        }

        fireGauge.fillAmount = fireFill;
        earthGauge.fillAmount = earthFill;
        waterGauge.fillAmount = waterFill;
        airGauge.fillAmount = airFill;

    }

    void UpdateGauges()
    {
        fireFill = ElementControllerScript.Fire / 12.0f;
        earthFill = ElementControllerScript.Earth / 12.0f;
        waterFill = ElementControllerScript.Water / 12.0f;
        airFill = ElementControllerScript.Wind / 12.0f;
    }


}
