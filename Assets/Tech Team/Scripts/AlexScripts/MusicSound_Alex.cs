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
    public AudioSource CaveMusic;
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
        if ((!CaveMusic.isPlaying) && currentScene == "CaveScene") // Cave Only
        {
            CaveMusic.Play();
        }
    }
    void Update()
    {
        VillageMusic.volume = AudioVolume;
        ForestMusic.volume = AudioVolume;
        MenuMusic.volume = AudioVolume;
        CaveMusic.volume = AudioVolume;
    }
    public void SoundToggle()
    {
        if (PlayerAudio.volume > 0f)
        {
            PlayerAudio.volume = 0f;
        }
        else
        {
            PlayerAudio.volume = 0.645f; //Hardcoded, need to change @AH
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
