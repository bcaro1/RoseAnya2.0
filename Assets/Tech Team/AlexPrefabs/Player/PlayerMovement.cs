﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    #region Public
    public bool canMove, onGround, isWalking;
    public Animator anim;
    public float turnSmoothTime, speedSmoothTime;
    public float walkSpeed;
    [Tooltip("Drag and drop Player's Element gameobject here")]  
    public GameObject element; // Element that's child of Player
    #endregion

    #region Private
    private Transform cameraT;
    private Rigidbody rb;
    private bool DoubleJumpInProgress;
    private float rbMass;
    float turnSmoothVelocity;
    float speedSmoothVelocity;
    float currentSpeed;
    private EventSystem Events;
    private ElementController_Joseph ElementControllerScript;
    #endregion

    void Awake()
    {
        // REFERENCES //
        cameraT = Camera.main.transform;
        rb = gameObject.GetComponent<Rigidbody>();
        rbMass = rb.mass;
        Events = EventSystem.current;
        ElementControllerScript = element.GetComponent<ElementController_Joseph>();
    }
    void Start()
    {
        canMove = true;
    }


    private void Update()
    {
        if(Events.IsPointerOverGameObject())
        {
            return;
        }

        if (canMove)
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 inputDir = input.normalized;

            if (inputDir != Vector2.zero)
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
            }

            float targetSpeed = walkSpeed * inputDir.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

            Walking();
            Jumping();
            DoubleJumping();
            Gliding();
        }
    }

    void Walking()
    {
        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical")) != 0)
        {
            transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

            if (onGround) { isWalking = true; } // using this bool for Sounds_Alex
            if (!onGround) { isWalking = false; }
        }
        else { isWalking = false; }
    }

    void Jumping()
    {
        if (onGround && Input.GetButtonDown("Jump")) //@AH
        {
            rb.AddForce(new Vector3(0, 15, 0), ForceMode.Impulse);
        }     
    }
    void DoubleJumping()
    {
        if (ElementControllerScript.Wind > 0)
        {
            if (!onGround && !DoubleJumpInProgress && Input.GetButtonDown("Jump")) //@AH
            {
                rb.AddForce(new Vector3(0, 15, 0), ForceMode.Impulse);
                DoubleJumpInProgress = true;
                ElementControllerScript.Wind --;
            }    
        }
  
    }
    void Gliding()
    {
        if (ElementControllerScript.Wind >= 1)
        {
            if (!onGround && DoubleJumpInProgress && Input.GetButtonDown("Jump")) //@AH
            {
                rb.mass = 1;
                ElementControllerScript.Wind --;
            }
            if (onGround || Input.GetKeyUp(KeyCode.Space))
            {
                rb.mass = rbMass;
            }     
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            DoubleJumpInProgress = false;
            rb.mass = rbMass;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
        }

        if (Input.GetButtonDown("Interact"))
        {
            if (other.gameObject.CompareTag("Item"))
            {
                other.gameObject.GetComponent<ItemPickup_Joseph>().Pickup();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }




}

