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
    private string currentScene;
    public static float AudioVolume = 1f;
    #endregion

    #region Public
    public AudioSource MenuMusic;
    public AudioSource VillageMusic;
    public AudioSource ForestMusic;
    #endregion

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name; // get active scene build index

        if (currentScene != "MainMenu(Yingying)") // Do this if NOT in Main Menu
        {
            // REFERENCES //
            Player = GameObject.FindGameObjectWithTag("Player");
            PlayerAudio = Player.GetComponent<AudioSource>();
        }
        if ((!MenuMusic.isPlaying) && currentScene == "MainMenu(Yingying)") // Village Only
        {
            MenuMusic.Play();
        }
        if ((!VillageMusic.isPlaying) && currentScene == "RoseAnya(new)") // Village Only
        {
            VillageMusic.Play();
        }
        if ((!ForestMusic.isPlaying) && currentScene == "Forest Level") // Forest Only
        {
            ForestMusic.Play();
        }
    }
    void Update()
    {
        VillageMusic.volume = AudioVolume;
        ForestMusic.volume = AudioVolume;
        MenuMusic.volume = AudioVolume;
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
