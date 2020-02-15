using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSound_Alex : MonoBehaviour
{
    #region Private
    private AudioSource PlayerAudio;
    private AudioSource AudioSrc;

    private GameObject Player;

    private float prevAudioVolume;
    private int currentScene;
    static float AudioVolume = 1f;
    #endregion
    void Awake()
    {
        // REFERENCES //
        AudioSrc = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene().buildIndex; // get active scene build index

        if (currentScene != 0) // Don't do this in Main Menu
        {
            // REFERENCES //
            Player = GameObject.FindGameObjectWithTag("Player");
            PlayerAudio = Player.GetComponent<AudioSource>();
        }
    }
    void Update()
    {
        AudioSrc.volume = AudioVolume;
    }
    public void SoundToggle()
    {
        if (PlayerAudio.volume > 0f)
        {
            PlayerAudio.volume = 0f;
        }
        else
        {
            PlayerAudio.volume = 0.645f;
        }
    }
    public void MusicToggle()
    {
        if (AudioVolume > 0f)
        { 
            prevAudioVolume = AudioVolume;
            AudioVolume = 0f;
        }
        else
        {
            AudioVolume = prevAudioVolume;
        }
    }
    public void VolumeSlider(float vol)
    {
        AudioVolume = vol;
    }
}
