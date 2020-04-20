using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ParticleSystem Water;
    void Awake()
    {
        Water.Stop();
    }

    void Update()
    {
        
    }
    public void WaterParticle()
    {
        StartCoroutine(CoWaterParticle());
    }
    private IEnumerator CoWaterParticle()
    {
        if (!Water.isPlaying) 
        { 
            Water.Play(); 
            yield return new WaitForSeconds(3.0f);
            Water.Stop();
            gameObject.SetActive(false);
        }
    }
}
