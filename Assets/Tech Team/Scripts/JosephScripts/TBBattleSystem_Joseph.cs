using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class TBBattleSystem_Joseph : MonoBehaviour
{
    #region Public
    public BattleState State;
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    public Transform PlayerBattlestation;
    public Transform EnemyBattlestation;
    public TextMeshProUGUI DialogueText;
    public TBBattleHUD_Joseph PlayerHUD;
    public TBBattleHUD_Joseph EnemyHUD;
    public string[] TextChoices;
    public string[] EnemyDialogue;
    public Button[] ActionButtons;
    #endregion

    #region Private
    private TBUnit_Joseph PlayerUnit;
    private TBUnit_Joseph EnemyUnit;
    #endregion

    void Start()
    {
        State = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject PlayerGo = Instantiate(PlayerPrefab, PlayerBattlestation);
        PlayerUnit = PlayerGo.GetComponent<TBUnit_Joseph>();

        GameObject EnemyGo = Instantiate(EnemyPrefab, EnemyBattlestation);
        EnemyUnit = EnemyGo.GetComponent<TBUnit_Joseph>();

        DialogueText.text = "A wild " + EnemyUnit.UnitName+ " approaches.";

        PlayerHUD.SetHUD(PlayerUnit);
        EnemyHUD.SetHUD(EnemyUnit);

        for(int i = 0; i < ActionButtons.Length; i++)
        {
            ActionButtons[i].interactable = false;
        }

        yield return new WaitForSecondsRealtime(2f);

        State = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack(int Type)
    {
        int Damage = PlayerUnit.Damage;
        string DamageText = " You seem to do damage.";

        if(Type != EnemyUnit.UnitType)
        {
            Damage = 0;
            DamageText = " They are unimpressed.";
        }

        bool IsDead = EnemyUnit.TakeDamage(Damage);

        EnemyHUD.SetHP(EnemyUnit.CurrentHP);

        DialogueText.text = TextChoices[Type] + DamageText;

        yield return new WaitForSecondsRealtime(2f);

        if(IsDead)
        {
            State = BattleState.WON;
            EndBattle();
        }
        else
        {
            State = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        for (int i = 0; i < ActionButtons.Length; i++)
        {
            ActionButtons[i].interactable = false;
        }

        DialogueText.text = EnemyUnit.UnitName + " attacks!";

        yield return new WaitForSecondsRealtime(1f);

        bool IsDead = PlayerUnit.TakeDamage(EnemyUnit.Damage);

        PlayerHUD.SetHP(PlayerUnit.CurrentHP);

        if(IsDead)
        {
            State = BattleState.LOST;
            EndBattle();
        }
        else
        {
            State = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(State == BattleState.WON)
        {
            DialogueText.text = "You Won!";
        }
        else if(State == BattleState.LOST)
        {
            DialogueText.text = "You Lost!";
        }
    }

    void PlayerTurn()
    {
        DialogueText.text = "Choose an action: ";

        for (int i = 0; i < ActionButtons.Length; i++)
        {
            ActionButtons[i].interactable = true;
        }
    }

    public void OnAttack1Button()
    {
        if(State != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack(0));
    }

    public void OnAttack2Button()
    {
        if (State != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack(1));
    }

    public void OnAttack3Button()
    {
        if (State != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack(2));
    }

    public void OnAttack4Button()
    {
        if (State != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack(3));
    }
}
