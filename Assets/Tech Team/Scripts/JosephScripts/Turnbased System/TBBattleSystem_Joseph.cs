using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, ESCAPED }

public class TBBattleSystem_Joseph : MonoBehaviour
{
    #region Public
    public BattleState State;
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    public GameObject TBCanvas;
    public Transform PlayerBattlestation;
    public Transform EnemyBattlestation;
    public TextMeshProUGUI DialogueText;
    public TBBattleHUD_Joseph PlayerHUD;
    public TBBattleHUD_Joseph EnemyHUD;
    public string[] TextChoices;
    public string[] EnemyDialogue;
    public Button[] ActionButtons;
    public GameObject MagicMenu;
    public Button[] MagicButtons;
    public int MagicCost = 5;
    #endregion

    #region Private
    private TBUnit_Joseph PlayerUnit;
    private TBUnit_Joseph EnemyUnit;
    private RPGController_Joseph Controller;
    #endregion

    void Start()
    {
        Controller = GameObject.FindGameObjectWithTag("Player").GetComponent<RPGController_Joseph>();
        State = BattleState.START;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        EnemyPrefab = StaticDatabase_Joseph.Enemy;
        AudioSource source = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        source.Stop();
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject PlayerGo = Instantiate(PlayerPrefab, PlayerBattlestation);
        PlayerUnit = PlayerGo.GetComponent<TBUnit_Joseph>();

        yield return new WaitForSecondsRealtime(.2f);

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

    IEnumerator PlayerAttack(int Type, bool Magic)
    {
        float Damage;
        if(Magic)
        {
            Damage = PlayerUnit.MagicDamage;
        }
        else
        {
            Damage = PlayerUnit.Damage;
        }     
        string DamageText = " You seem to do damage.";

        if(Type == EnemyUnit.UnitType)
        {
            Damage = Damage * 1.5f;
            DamageText = " The attack seems very effective.";
        }

        bool IsDead = EnemyUnit.TakeDamage((int)Damage);

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

    IEnumerator RunAttempt(bool escaped)
    {
        string EscapeText = "You failed to escape";
        if(escaped)
        {
            EscapeText = "You managed to run away.";
        }

        DialogueText.text = EscapeText;

        yield return new WaitForSecondsRealtime(2f);

        if(escaped)
        {
            State = BattleState.ESCAPED;
            EndBattle();
        }
        else
        {
            State = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator LevelUp()
    {
        yield return new WaitForSecondsRealtime(1f);

        DialogueText.text = "You leveled up! You are now level " + Controller.Level + ".";

        yield return new WaitForSecondsRealtime(2f);

        DialogueText.text = "Your HP is now " + Controller.HP + " and your Attack and Magic attack are " + Controller.Attack + ", and " + Controller.MagicAttack + " respectively.";

        yield return new WaitForSecondsRealtime(2f);

        CheckMultipleLevelUp();
    }

    IEnumerator EndTheBattle()
    {
        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Destroy(TBCanvas);

    }

    IEnumerator LostTheBattle()
    {
        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        yield return new WaitForSecondsRealtime(.2f);

        Destroy(TBCanvas);
        SceneManager.LoadScene(3);
    }

    void CheckMultipleLevelUp()
    {
        if(Controller.CheckLevelUp())
        {
            PlayerUnit.UnitLevel = Controller.Level;
            PlayerHUD.SetHUD(PlayerUnit);
            StartCoroutine(LevelUp());
        }
        else
        {
            StartCoroutine(EndTheBattle());
        }
    }

    void EndBattle()
    {
        if(State == BattleState.WON)
        {
            DialogueText.text = "You Won! You gained " + EnemyUnit.EXP + " Experience Points!";
            
            if(Controller.GetEXP(EnemyUnit.EXP))
            {
                PlayerUnit.UnitLevel = Controller.Level;
                PlayerUnit.CurrentHP = PlayerUnit.MaxHP;
                PlayerHUD.SetHUD(PlayerUnit);
                StartCoroutine(LevelUp());
            }
            else
            {
                StartCoroutine(EndTheBattle());
            }
        }
        else if(State == BattleState.LOST)
        {
            DialogueText.text = "You Lost!";
            StartCoroutine(LostTheBattle());
        }
        else if(State == BattleState.ESCAPED)
        {
            DialogueText.text = "You managed to run away.";
            StartCoroutine(EndTheBattle());
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

    public void OnAttackButton()
    {
        if (State != BattleState.PLAYERTURN)
        {
            return;
        }
        MagicMenu.SetActive(false);
        StartCoroutine(PlayerAttack(0, false));
    }

    public void OnMagicButton()
    {
        if(State != BattleState.PLAYERTURN)
        {
            return;
        }

        if(MagicMenu.activeSelf)
        {
            MagicMenu.SetActive(false);
        }
        else
        {
            MagicMenu.SetActive(true);
            if (MagicCost > StaticDatabase_Joseph.Water)
            {
                MagicButtons[0].interactable = false;
            }
            if (MagicCost > StaticDatabase_Joseph.Wind)
            {
                MagicButtons[1].interactable = false;
            }
            if (MagicCost > StaticDatabase_Joseph.Earth)
            {
                MagicButtons[2].interactable = false;
            }
            if (MagicCost > StaticDatabase_Joseph.Fire)
            {
                MagicButtons[3].interactable = false;
            }
        }
    }

    public void OnItemButton()
    {
        MagicMenu.SetActive(false);
    }

    public void OnRunButton()
    {
        MagicMenu.SetActive(false);
        int escape = Random.Range(0, 100);
        StartCoroutine(RunAttempt(escape < EnemyUnit.EscapeChance));
    }

    public void OnWaterButton()
    {
        if(State != BattleState.PLAYERTURN)
        {
            return;
        }
        MagicMenu.SetActive(false);
        StaticDatabase_Joseph.Water -= MagicCost;
        StartCoroutine(PlayerAttack(1, true));
    }

    public void OnWindButton()
    {
        if (State != BattleState.PLAYERTURN)
        {
            return;
        }
        MagicMenu.SetActive(false);
        StaticDatabase_Joseph.Wind -= MagicCost;
        StartCoroutine(PlayerAttack(2, true));
    }

    public void OnEarthButton()
    {
        if (State != BattleState.PLAYERTURN)
        {
            return;
        }
        MagicMenu.SetActive(false);
        StaticDatabase_Joseph.Earth -= MagicCost;
        StartCoroutine(PlayerAttack(3, true));
    }

    public void OnFireButton()
    {
        if (State != BattleState.PLAYERTURN)
        {
            return;
        }
        MagicMenu.SetActive(false);
        StaticDatabase_Joseph.Fire -= MagicCost;
        StartCoroutine(PlayerAttack(4, true));
    }

}
