using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMechanics : MonoBehaviour
{
    #region Public
    public float velocity = 1;
    #endregion

    #region Private
    private Rigidbody2D rb;
    #endregion

    void Start()
    {
        // REFERENCES //
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // Jump
            rb.velocity = Vector2.up * velocity;
        }
    }
}
