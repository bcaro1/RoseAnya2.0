using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform_Joseph : MonoBehaviour
{
    #region Public
    public int TimeBeforeSinking = 3;
    public int DistanceToSink = 15;
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        //Checks to see if colliding with the player, if so starts the timer to sink
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Sink());
        }
    }

    IEnumerator Sink()
    {
        int sink;
        yield return new WaitForSecondsRealtime(TimeBeforeSinking);
        //Put animation of sinking here
        //Put delay waiting for animation to finish here
        //Replace Below with just Gameobject.setactive(false)
        transform.position = new Vector3(transform.position.x, transform.position.y - DistanceToSink, transform.position.z);
    }
}
