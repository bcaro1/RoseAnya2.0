using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float waitTime;
    public GameObject pipe;
    public float height;
    public Transform GamePanel;
    private float timer = 0;
    void Start()
    {
        
    }

    void Update()
    {        
        if (timer > waitTime)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            newPipe.transform.SetParent(GamePanel, false);
            Debug.Log(newPipe.transform.position);
            Destroy(newPipe, 15);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
