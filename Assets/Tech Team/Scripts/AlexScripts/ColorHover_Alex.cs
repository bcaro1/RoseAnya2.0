using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorHover_Alex : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Public
    [Header("Hover Text")]
    public Text ResumeText;
    public Text OptionsText;
    public Text ControlsText;
    public Text CreditsText;
    public Text ResetText;
    public Text QuitText;
    #endregion

    #region Private
    private Color maroon;
    private 
    #endregion
    void Awake()
    {
        maroon = new Color32(145,1,1,255);
    }
    void Update()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.name == "ResumeButton")
        {
            ResumeText.color = maroon;
        } 
        else if (gameObject.name == "OptionsButton")
        {
            OptionsText.color = maroon;
        }
        else if (gameObject.name == "ControlsButton")
        {
            ControlsText.color = maroon;
        }
        else if (gameObject.name == "CreditsButton")
        {
            CreditsText.color = maroon;
        }
        else if (gameObject.name == "QuitButton")
        {
            QuitText.color = maroon;
        }
        else if (gameObject.name == "ResetButton")
        {
            QuitText.color = maroon;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject.name == "ResumeButton")
        {
            ResumeText.color = Color.black;
        } 
        else if (gameObject.name == "OptionsButton")
        {
            OptionsText.color = Color.black;
        }
        else if (gameObject.name == "ControlsButton")
        {
            ControlsText.color = Color.black;
        }
        else if (gameObject.name == "CreditsButton")
        {
            CreditsText.color = Color.black;
        }
        else if (gameObject.name == "QuitButton")
        {
            QuitText.color = Color.black;
        }
        else if (gameObject.name == "ResetButton")
        {
            QuitText.color = Color.black;
        }
    }
}
