using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength_Alex : MonoBehaviour
{
    #region Public
    public GameObject strengthObject; //This is the object the player will be "picking up"
    public float height;
    public bool CurrentlyUsingStrength;
    #endregion

    #region Private
    private Vector3 startPosition; //This is the current position
    private float dotProd; //Returns 1 if 2 objects point in the same direction
    private Rigidbody strengthObjectRigidbody; // Rigidbody of strength object
    #endregion

    void Awake()
    {
        // ASSIGNING VARIABLES //
        CurrentlyUsingStrength = false;
    }

    void Update()
    {
        if (Input.GetButtonUp("Strength") && CurrentlyUsingStrength) 
        {
            CurrentlyUsingStrength = false;
            ReleaseStrength();
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Strength")
        {
            // var strengthCollider = collider.gameObject.transform;
            // strengthObject = strengthCollider.gameObject;
            // strengthObjectRigidbody = strengthObject.GetComponent<Rigidbody>();

            if (Input.GetButtonDown("Strength") && collider.gameObject.tag == "Strength")
            {
                // set the collider to strengthCollider
                var strengthCollider = collider.gameObject.transform;
                // grab strengthCollider's gameobject and store in strengthObject
                strengthObject = strengthCollider.gameObject;
                // Gathers strengthObject and Player's current position
                Vector3 dirFromAtoB = (strengthObject.transform.position - this.gameObject.transform.position).normalized;
                // Gathers direction of Player
                dotProd = Vector3.Dot(dirFromAtoB, this.gameObject.transform.forward);

                // If Player is facing strengthObject...
                if (dotProd > 0.85) 
                {
                    CurrentlyUsingStrength = true;
                    // Make strength object the child of the player
                    strengthObject.transform.parent = this.gameObject.transform;
                    // Set current position of strengthObject to startPosition
                    startPosition = strengthObject.transform.position;
                    // Move strengthObject up
                    strengthObject.transform.position = new Vector3(startPosition.x, startPosition.y + height, startPosition.z);
                    // Set rigidbody of strengthObject to strengthObjectRigidbody
                    strengthObjectRigidbody = strengthObject.GetComponent<Rigidbody>();
                    // Turn on Kinematic...this means the strengthObject won't fall
                    strengthObjectRigidbody.isKinematic = true;
                }
            }
        }
    }

    void ReleaseStrength()
    {
        strengthObject.transform.parent = null;
        strengthObjectRigidbody.WakeUp();
        strengthObjectRigidbody.isKinematic = false;
    }
}
