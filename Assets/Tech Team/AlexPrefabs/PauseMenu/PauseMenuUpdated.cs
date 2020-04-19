using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUpdated : MonoBehaviour
{
    #region Public
    public GameObject sideMenuUI, pauseMenuUI, optionsMenuUI, controlsMenuUI, confirmMenuUI;
    public GameObject Player, CameraBase;

    [Header("Hover Text")]

    public Text ResumeText, OptionsText, ControlsText, CreditsText, QuitText;
    #endregion

    #region Private
    CameraFollow_Joseph CameraFollowScript;
    private Color maroon;
    private bool IsPaused = false;
    #endregion

    void Awake()
    {
        // REFERENCES //
        CameraFollowScript = CameraBase.GetComponent<CameraFollow_Joseph>();

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
        sideMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        confirmMenuUI.SetActive(false);

        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        sideMenuUI.SetActive(true);
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
