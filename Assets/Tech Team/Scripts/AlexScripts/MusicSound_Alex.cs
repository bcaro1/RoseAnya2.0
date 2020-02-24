using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSound_Alex : MonoBehaviour
{
    #region Private
    private AudioSource PlayerAudio;
    private GameObject Player;
    private float prevAudioVolume;
    private int currentScene;
    static float AudioVolume = 1f;
    #endregion

    #region Public
    public AudioSource VillageMusic;
    public AudioSource ForestMusic;
    #endregion

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex; // get active scene build index

        if (currentScene != 0) // Do this if NOT in Main Menu
        {
            // REFERENCES //
            Player = GameObject.FindGameObjectWithTag("Player");
            PlayerAudio = Player.GetComponent<AudioSource>();
        }
        if ((!VillageMusic.isPlaying) && currentScene == 4) // Village Only
        {
            VillageMusic.Play();
        }
        if ((!ForestMusic.isPlaying) && currentScene == 5) // Forest Only
        {
            ForestMusic.Play();
        }
    }
    void Update()
    {
        VillageMusic.volume = AudioVolume;
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
