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

        Water.enableEmission = false;
        Fire.enableEmission = false;
        Wind.enableEmission = false;
        Earth.enableEmission = false;
    }

    void Update()
    {
        
    }
    public void WaterParticle()
    {
        // Debug.Log("Play Water");
        StartCoroutine(CoWaterParticle());
    }
    public void FireParticle()
    {
        // Debug.Log("Play Fire");
        StartCoroutine(CoFireParticle());
    }
    public void WindParticle()
    {
        // Debug.Log("Play Wind");
        StartCoroutine(CoWindParticle());
    }
    public void EarthParticle()
    {
        // Debug.Log("Play Earth");
        StartCoroutine(CoEarthParticle());
    }
    private IEnumerator CoWaterParticle()
    {
        Water.enableEmission = true;
        Water.Play(); 
        yield return new WaitForSeconds(2.0f);
        Water.Stop();
        Water.enableEmission = false;
        gameObject.SetActive(false);
    }
    private IEnumerator CoFireParticle()
    {
        Fire.enableEmission = true;
        Fire.Play(); 
        yield return new WaitForSeconds(2.0f);
        Fire.Stop();
        Fire.enableEmission = false;
        gameObject.SetActive(false);
    }
    private IEnumerator CoWindParticle()
    {
        Wind.enableEmission = true;
        Wind.Play(); 
        yield return new WaitForSeconds(2.0f);
        Wind.Stop();
        Wind.enableEmission = false;
        gameObject.SetActive(false);

    }
    private IEnumerator CoEarthParticle()
    {
        Earth.enableEmission = true;
        Earth.Play(); 
        yield return new WaitForSeconds(2.0f);
        Earth.Stop();
        Earth.enableEmission = false;
        gameObject.SetActive(false);
    }
}
