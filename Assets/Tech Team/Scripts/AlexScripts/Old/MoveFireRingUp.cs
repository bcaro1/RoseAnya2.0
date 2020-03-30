using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFireRingUp : MonoBehaviour
{
    ///////// SETUP /////////
    public static bool startPlaying;
    public GameObject FireRing;
    /////////////////////////
    void Start()
    {
        startPlaying = false;
    }
    void Update()
    {
        Checker();
    }

    ///////// FUNCTIONS /////////

    // broken :( //
    void Checker()
    {
        if (startPlaying)
        {
            StartCoroutine(MoveUp());
        }
    }
    // broken :( //
    IEnumerator MoveUp()
    {
        // turn on particle effect //
        FireRing.SetActive (true);
        // move particle effect up //
        transform.Translate(Vector3.forward * Time.deltaTime);

        yield return new WaitForSeconds(2);
        // turn off particle effect //
        FireRing.SetActive (false);

        startPlaying = false;
    }
}
