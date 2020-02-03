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

    public GameObject element;
    private ElementController_Joseph ElementControllerScript;
    void Start()
    {
        ElementControllerScript = element.GetComponent<ElementController_Joseph>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //THIS WILL CHANGE TO WHATEVER KEY WE USE TO ABSORB / DISCHARGE ELEMENTS
        {
            UpdateGauges();
        }
    }

    void UpdateGauges()
    {
        fireGauge.fillAmount = ElementControllerScript.Fire / 12.0f;
        earthGauge.fillAmount = ElementControllerScript.Earth / 12.0f;
        waterGauge.fillAmount = ElementControllerScript.Water / 12.0f;
        airGauge.fillAmount = ElementControllerScript.Wind / 12.0f;
    }


}
