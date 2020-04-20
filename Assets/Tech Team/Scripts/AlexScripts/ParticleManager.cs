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
        Debug.Log("Play Water");
        StartCoroutine(CoWaterParticle());
    }
    public void FireParticle()
    {
        Debug.Log("Play Fire");
        StartCoroutine(CoFireParticle());
    }
    public void WindParticle()
    {Debug.Log("Play Wind");
        StartCoroutine(CoWindParticle());
    }
    public void EarthParticle()
    {
        Debug.Log("Play Earth");
        StartCoroutine(CoEarthParticle());
    }
    private IEnumerator CoWaterParticle()
    {
        if (!Water.isPlaying) 
        { 
            Water.Play(); 
            yield return new WaitForSeconds(2.0f);
            Water.Stop();
            gameObject.SetActive(false);
        }
    }
    private IEnumerator CoFireParticle()
    {
        if (!Fire.isPlaying) 
        { 
            Fire.Play(); 
            yield return new WaitForSeconds(2.0f);
            Fire.Stop();
            gameObject.SetActive(false);
        }
    }
    private IEnumerator CoWindParticle()
    {
        if (!Wind.isPlaying) 
        { 
            Wind.Play(); 
            yield return new WaitForSeconds(2.0f);
            Wind.Stop();
            gameObject.SetActive(false);
        }
    }
    private IEnumerator CoEarthParticle()
    {
        if (!Earth.isPlaying) 
        { 
            Earth.Play(); 
            yield return new WaitForSeconds(2.0f);
            Earth.Stop();
            gameObject.SetActive(false);
        }
    }
}
