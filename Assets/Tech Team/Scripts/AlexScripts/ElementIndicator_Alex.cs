using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementIndicator_Alex : MonoBehaviour
{
    #region Public
    public GameObject Element;
    public GameObject waterUI;
    public GameObject fireUI;
    public GameObject windUI;
    public GameObject earthUI;
    #endregion

    #region Private
    private ElementController_Joseph ElementControllerScript;
    #endregion
    void Awake()
    {
        // REFERENCES //
        ElementControllerScript = Element.GetComponent<ElementController_Joseph>();
    }


    void Update()
    {
        StartCoroutine(MainIndicator());
    }
    
    private IEnumerator MainIndicator()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            yield return new WaitForSeconds(0.1f);
            if (ElementControllerScript.CurrentElement == 0)
            {
                StartCoroutine(WaterIndicator());
            }
            else if (ElementControllerScript.CurrentElement == 1)
            {
                StartCoroutine(WindIndicator());
            }
            else if (ElementControllerScript.CurrentElement == 2)
            {
                StartCoroutine(EarthIndicator());
            }
            else if (ElementControllerScript.CurrentElement == 3)
            {
                StartCoroutine(FireIndicator());
            }
        }
    }
    private IEnumerator WaterIndicator()
    {
        waterUI.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        waterUI.SetActive(false);
    }
    private IEnumerator FireIndicator()
    {
        fireUI.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        fireUI.SetActive(false);
    }
    private IEnumerator WindIndicator()
    {
        windUI.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        windUI.SetActive(false);
    }
    private IEnumerator EarthIndicator()
    {
        earthUI.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        earthUI.SetActive(false);
    }
}
