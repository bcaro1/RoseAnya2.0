using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMechanics : MonoBehaviour
{
    #region Public
    public float velocity = 1;
    public GameObject GameManagerCanvas;
    #endregion

    #region Private
    private Rigidbody2D rb;
    private MinigameManager GameManagerScript;
    #endregion

    void Start()
    {
        // REFERENCES //
        rb = GetComponent<Rigidbody2D>();
        GameManagerScript = GameManagerCanvas.GetComponent<MinigameManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // Jump
            rb.velocity = Vector2.up * velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManagerScript.GameOver();
    }
}
