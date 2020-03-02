using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove, onGround;
    private Transform cameraT;
    public AudioSource walkSound; //This is the sound for walking
    public Animator anim;
    float turnSmoothVelocity;
    float speedSmoothVelocity;
    public float turnSmoothTime, speedSmoothTime;
    float currentSpeed;
    public float walkSpeed;
    private Rigidbody rb;
    private bool DoubleJumpInProgress;
    private float rbMass;

    void Awake()
    {
        cameraT = Camera.main.transform;
        rb = gameObject.GetComponent<Rigidbody>();
        rbMass = rb.mass;
    }
    void Start()
    {
        canMove = true;
    }


    private void Update()
    {
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
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
            if (!walkSound.isPlaying && onGround)
            {
                walkSound.Play();
            }
            if (!onGround) 
            {
                walkSound.Pause();
            }
        }
        else
        {
            walkSound.Pause();
        }
    }

    void Jumping()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 15, 0), ForceMode.Impulse);
        }     
    }
    void DoubleJumping()
    {
        if (!onGround && !DoubleJumpInProgress && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 15, 0), ForceMode.Impulse);
            DoubleJumpInProgress = true;
        }     
    }
    void Gliding()
    {
        if (!onGround && DoubleJumpInProgress && Input.GetKeyDown(KeyCode.Space))
        {
            rb.mass = 1;
        }
        if (onGround || Input.GetKeyUp(KeyCode.Space))
        {
            rb.mass = rbMass;
        }     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            DoubleJumpInProgress = false;
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

