using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ParticleSystem Water;
    public ParticleSystem Fire;
    public ParticleSystem Wind;
    public ParticleSystem Earth;
    void Awake()
    {
        Water.Stop();
        Fire.Stop();
        Wind.Stop();
        Earth.Stop();
    }

    void Update()
    {
        
    }
    public void WaterParticle()
    {
        StartCoroutine(CoWaterParticle());
    }
    public void FireParticle()
    {
        StartCoroutine(CoFireParticle());
    }
    public void WindParticle()
    {
        StartCoroutine(CoWindParticle());
    }
    public void EarthParticle()
    {
        StartCoroutine(CoEarthParticle());
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
    private IEnumerator CoFireParticle()
    {
        if (!Fire.isPlaying) 
        { 
            Fire.Play(); 
            yield return new WaitForSeconds(3.0f);
            Fire.Stop();
            gameObject.SetActive(false);
        }
    }
    private IEnumerator CoWindParticle()
    {
        if (!Wind.isPlaying) 
        { 
            Wind.Play(); 
            yield return new WaitForSeconds(3.0f);
            Wind.Stop();
            gameObject.SetActive(false);
        }
    }
    private IEnumerator CoEarthParticle()
    {
        if (!Earth.isPlaying) 
        { 
            Earth.Play(); 
            yield return new WaitForSeconds(3.0f);
            Earth.Stop();
            gameObject.SetActive(false);
        }
    }
}
