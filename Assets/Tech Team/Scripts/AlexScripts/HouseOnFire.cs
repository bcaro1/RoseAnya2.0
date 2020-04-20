using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus; // access to fungus
public class HouseOnFire : MonoBehaviour
{
    #region Public
    // public GameObject[] fire;
    public Flowchart flowchart;
    public GameObject Door3;
    #endregion

    #region Private

    #endregion

    void Start()
    {
        Door3.SetActive(false);
        StartFire();
    }


    void Update()
    {
        CompleteFire();
    }

    public IEnumerator StartFire()
    {
        yield return new WaitForSeconds(10f);
        FireTimeout();
    }
    public void FireTimeout()
    {
        Door3.SetActive(true);
        gameObject.SetActive(false);
    }
    public void CompleteFire()
    {
        if (gameObject.transform.position.y < -9)
        {
            flowchart.SetIntegerVariable("HouseFire", 2);
            Door3.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
