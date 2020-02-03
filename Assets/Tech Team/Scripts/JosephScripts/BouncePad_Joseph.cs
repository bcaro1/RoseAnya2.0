using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad_Joseph : MonoBehaviour
{
    #region Public
    public int BounceForce = 500;
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        GameObject Hold = collision.gameObject;

        if(Hold.CompareTag("Player"))
        {
            Rigidbody RB = Hold.GetComponent<Rigidbody>();
            RB.AddForce(Vector3.up * BounceForce);
        }
    }
}
