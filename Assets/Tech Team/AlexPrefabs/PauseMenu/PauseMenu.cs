using System.Collections;
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
    CameraFollow_Joseph CameraFollowScript;
    private Color maroon;
    private GameObject SoundPlayer;
    private Sounds_Alex SoundsScript;
    #endregion

    void Awake()
    {
        // REFERENCES //
        CameraFollowScript = CameraBase.GetComponent<CameraFollow_Joseph>();
        SoundPlayer = GameObject.FindGameObjectWithTag("SoundPlayer");
        SoundsScript = SoundPlayer.GetComponent<Sounds_Alex>();

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
}
