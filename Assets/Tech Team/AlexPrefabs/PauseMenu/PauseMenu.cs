﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Hover Text")]
    public Text ResumeText;
    public Text TasksText;
    public Text OptionsText;
    public Text ControlsText;
    public Text CreditsText;
    public Text QuitText;
    #endregion

    #region Private
    AudioSource PlayerAudio;
    CameraFollow_Joseph CameraFollowScript;
    private Color maroon;
    #endregion

    void Awake()
    {
        // REFERENCES //
        CameraFollowScript = CameraBase.GetComponent<CameraFollow_Joseph>();
        PlayerAudio = Player.GetComponent<AudioSource>();

        // VARIABLES //
        maroon = new Color32(145,1,1,255);
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

    public void ActiveColor()
    {
        // OptionsText.color = optionsMenuUI.activeSelf == true ? maroon : Color.black;
        // TasksText.color = tasksMenuUI.activeSelf == true ? maroon : Color.black;
        // ControlsText.color = controlsMenuUI.activeSelf == true ? maroon : Color.black;
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
