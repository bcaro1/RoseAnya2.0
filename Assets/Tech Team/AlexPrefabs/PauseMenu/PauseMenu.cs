using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject tasksMenuUI;
    public GameObject Camera;
    AudioSource CameraAudio;
    public GameObject Player;
    AudioSource PlayerAudio;
    CameraFollow_Joseph CameraFollowScript;

    void Awake()
    {
        CameraFollowScript = Camera.GetComponent<CameraFollow_Joseph>();
        CameraAudio = Camera.GetComponent<AudioSource>();
        PlayerAudio = Player.GetComponent<AudioSource>();
    } 
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.P))
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

    public void Sound()
    {
        if (PlayerAudio.volume == 0.645f)
        {
            PlayerAudio.volume = 0f;
        }
        else
        {
            PlayerAudio.volume = 0.645f;
        }
    }
    public void Music()
    {
        if (CameraAudio.volume == 1f)
        {
            CameraAudio.volume = 0f;
        }
        else
        {
            CameraAudio.volume = 1f;
        }
    }

}
