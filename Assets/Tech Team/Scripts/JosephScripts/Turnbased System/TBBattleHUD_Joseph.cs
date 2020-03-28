using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TBBattleHUD_Joseph : MonoBehaviour
{
    #region Public
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI LevelText;
    public Slider HPSlider;
    #endregion

    public void SetHUD(TBUnit_Joseph Unit)
    {
        NameText.text = Unit.UnitName;
        LevelText.text = "Lvl. " + Unit.UnitLevel;
        HPSlider.maxValue = (float) Unit.MaxHP;
        HPSlider.value = (float) Unit.CurrentHP;
    }

    public void SetHP(int HP)
    {
        HPSlider.value = HP;
    }
}
