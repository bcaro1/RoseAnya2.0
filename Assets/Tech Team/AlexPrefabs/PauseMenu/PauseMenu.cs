using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    #region Public
    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject tasksMenuUI;
    public GameObject controlsMenuUI;
    public GameObject CameraBase;
    public AudioSource VillageMusic;
    public AudioSource ForestMusic;
    public GameObject Player;
    #endregion

    #region Private
    AudioSource PlayerAudio;
    CameraFollow_Joseph CameraFollowScript;
    #endregion

    void Awake()
    {
        // REFERENCES //
        CameraFollowScript = CameraBase.GetComponent<CameraFollow_Joseph>();
        PlayerAudio = Player.GetComponent<AudioSource>();
    } 
    void Update()
    {
       if (Input.GetButtonDown("Cancel")) 
       {
           if (IsPaused)
           {
               Resume();
           }
           else
           {
               Pause();
           }
       } 
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        tasksMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);

        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Quit()
    {
        Application.Quit();
        Cursor.visible = true;
    }

    public void AdjustSensitivity(float newSpeed)
    {
        CameraFollowScript.InputSensitivity = newSpeed;
    }

    // public void Sound()
    // {
    //     if (PlayerAudio.volume > 0f)
    //     {
    //         PlayerAudio.volume = 0f;
    //     }
    //     else
    //     {
    //         PlayerAudio.volume = 0.645f; // Hardcoded, will change @AH
    //     }
    // }
    // public void Music()
    // {

    //     if (VillageMusic.volume > 0f || ForestMusic.volume > 0f)
    //     {
    //         VillageMusic.volume = 0f;
    //         ForestMusic.volume = 0f;
    //     }
    //     else
    //     {
    //         VillageMusic.volume = MusicSound_Alex.AudioVolume;
    //         ForestMusic.volume = MusicSound_Alex.AudioVolume;
    //     }

    // }

}
