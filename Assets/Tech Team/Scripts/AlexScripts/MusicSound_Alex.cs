using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSound_Alex : MonoBehaviour
{
    #region Private
    private AudioSource PlayerAudio;
    private GameObject Player, SoundPlayer;
    private float prevAudioVolume;
    private string currentScene;
    private Sounds_Alex SoundsScript;
    #endregion

    #region Public
    public AudioSource MenuMusic;
    public AudioSource VillageMusic;
    public AudioSource ForestMusic;
    public AudioSource CaveMusic;
    public AudioSource CastleMusic;

    public static float AudioVolume = 1f;
    #endregion

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name; // get active scene build index

        if (currentScene != "MainMenu(Yingying)") // Do this if NOT in Main Menu
        {
            // REFERENCES //
            Player = GameObject.FindGameObjectWithTag("Player");
            PlayerAudio = Player.GetComponent<AudioSource>();
            SoundPlayer = GameObject.FindGameObjectWithTag("SoundPlayer");
            SoundsScript = SoundPlayer.GetComponent<Sounds_Alex>();
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
        if ((!CastleMusic.isPlaying) && currentScene == "Castle Scene") // Castle Only
        {
            CastleMusic.Play();
        }
    }

    private void OnEnable()
    {
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
        if ((!CastleMusic.isPlaying) && currentScene == "Castle Scene") // Castle Only
        {
            CastleMusic.Play();
        }
    }

    private void OnDisable()
    {
        MenuMusic.Stop();
        VillageMusic.Stop();
        ForestMusic.Stop();
        CaveMusic.Stop();
        CastleMusic.Stop();
    }

    void Update()
    {
        VillageMusic.volume = AudioVolume;
        ForestMusic.volume = AudioVolume;
        MenuMusic.volume = AudioVolume;
        CaveMusic.volume = AudioVolume;
        CastleMusic.volume = AudioVolume;
    }

    public void SoundToggle()
    {
        if (SoundsScript.soundToggle) { SoundsScript.soundToggle = false; }
        else { SoundsScript.soundToggle = true; }
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
