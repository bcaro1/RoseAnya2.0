using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameEntry_Joseph : MonoBehaviour
{
    #region Public
    public GameObject Textbox;
    public TMP_InputField NameInput;
    public TextMeshProUGUI ErrorText;
    #endregion

    #region Private
    private string PlayerName;
    #endregion

    public void ClearError()
    {
        ErrorText.text = "";
    }

    public void Submit()
    {
        if(string.IsNullOrEmpty(NameInput.text))
        {
            ErrorText.text = "Please enter a valid name.";
        }
        else
        {
            StaticDatabase_Joseph.CharacterName = NameInput.text;
            PlayerPrefs.SetString("CurrentFile", StaticDatabase_Joseph.CharacterName + ".json");
            Destroy(Textbox);
        }
    }
}
