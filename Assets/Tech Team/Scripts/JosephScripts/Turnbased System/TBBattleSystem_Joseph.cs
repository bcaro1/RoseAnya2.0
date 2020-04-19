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
    public GameObject ItemMenu;
    public Button[] MagicButtons;
    public int MagicCost = 4;
    public Image BG;
    #endregion

    #region Private
    private TBUnit_Joseph PlayerUnit;
    private TBUnit_Joseph EnemyUnit;
    private RPGController_Joseph Controller;
    private GameObject Sound;
    private AudioSource Source;
    #endregion

    void Start()
    {
        Source = GetComponent<AudioSource>();
        Source.clip = StaticDatabase_Joseph.BGM;
        Source.Play();
        Controller = GameObject.FindGameObjectWithTag("Player").GetComponent<RPGController_Joseph>();
        Sound = GameObject.FindGameObjectWithTag("MusicPlayer");
        Sound.SetActive(false);
        State = BattleState.START;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        EnemyPrefab = StaticDatabase_Joseph.Enemy;
        BG.sprite = StaticDatabase_Joseph.BackGround;
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

        for (int i = 0; i < ActionButtons.Length; i++)
        {
            ActionButtons[i].interactable = false;
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

    IEnumerator UseItem()
    {
        DialogueText.text = "You use an item to recover some energy.";
        PlayerHUD.SetHP(StaticDatabase_Joseph.CurrentHP);
        PlayerUnit.CurrentHP = StaticDatabase_Joseph.CurrentHP;
        yield return new WaitForSecondsRealtime(2f);
        StartCoroutine(EnemyTurn());
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
        StaticDatabase_Joseph.CurrentHP = PlayerUnit.CurrentHP;
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
        Source.Stop();
        Sound.SetActive(true);

        Destroy(TBCanvas);

    }

    IEnumerator LostTheBattle()
    {
        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Source.Stop();
        Sound.SetActive(true);

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
        ItemMenu.SetActive(false);
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
            ItemMenu.SetActive(false);
            MagicMenu.SetActive(true);


            if (MagicCost > StaticDatabase_Joseph.Water)
            {
                MagicButtons[0].interactable = false;
            }
            else
            {
                MagicButtons[0].interactable = true;
            }

            if (MagicCost > StaticDatabase_Joseph.Wind)
            {
                MagicButtons[1].interactable = false;
            }
            else
            {
                MagicButtons[1].interactable = true;
            }

            if (MagicCost > StaticDatabase_Joseph.Earth)
            {
                MagicButtons[2].interactable = false;
            }
            else
            {
                MagicButtons[2].interactable = true;
            }

            if (MagicCost > StaticDatabase_Joseph.Fire)
            {
                MagicButtons[3].interactable = false;
            }
            else
            {
                MagicButtons[3].interactable = true;
            }
        }
    }

    public void OnItemButton()
    {

        if(State != BattleState.PLAYERTURN)
        {
            return;
        }
        
        if(ItemMenu.activeSelf)
        {
            ItemMenu.SetActive(false);
        }
        else
        {
            MagicMenu.SetActive(false);
            ItemMenu.SetActive(true);
        }
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

    public void OnItemUse()
    {
        ItemMenu.SetActive(false);
        StartCoroutine(UseItem());
    }

}
