using UnityEngine;
using System.Collections;

public class WaterBob : MonoBehaviour
{
    // User Inputs
    public float amplitude = 0.5f;
    public float frequency = 1f;
 
    // Position Storage Variables
    Vector3 posOffset = new Vector3 ();
    Vector3 tempPos = new Vector3 ();
 
    // Use this for initialization
    void Start () {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }
     
    // Update is called once per frame
    void Update () { 
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
 
        transform.position = tempPos;
    }









    // [SerializeField]
    // float height = 0.1f;

    // [SerializeField]
    // float period = 1;

    // private Vector3 initialPosition;
    // private float offset;

    // private void Awake()
    // {
    //     initialPosition = transform.position;

    //     offset = 1 - (Random.value * 2);
    // }

    // private void Update()
    // {
    //     transform.position = initialPosition - Vector3.up * Mathf.Sin((Time.time + offset) * period) * height;
    // }
}
