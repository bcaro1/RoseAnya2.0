using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; // access to fungus
public class HouseOnFire : MonoBehaviour
{
    #region Public
    public GameObject[] fire;
    public Flowchart flowchart;
    #endregion

    #region Private

    #endregion

    void Awake()
    {
        
    }


    void Update()
    {
        // CompleteFire();
    }

    public IEnumerator StartFire()
    {
        for(var i = 0; i < fire.Length; i++)
        {
            gameObject.SetActive(true);
            fire[i].SetActive(true);
        }

        yield return new WaitForSeconds(30f);
        FireTimeout();
    }
    public void FireTimeout()
    {
        for(var i = 0; i < fire.Length; i++)
        {
            fire[i].SetActive(false);
        }
        gameObject.SetActive(false);
        
    }
    public void CompleteFire()
    {
        // if gameobject position = ...
        flowchart.SetIntegerVariable("HouseFire", 2);
        for(var i = 0; i < fire.Length; i++)
        {
            fire[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
