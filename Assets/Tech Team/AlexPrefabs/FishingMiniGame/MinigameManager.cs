using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinigameManager : MonoBehaviour
{
    #region Public
    public GameObject FishingMinigame, Player, CollectFish;
    public GameObject ChickenEnemy;
    public static int score = 0;
    #endregion

    #region Private
    private PlayerMovement PlayerMovementScript;
    private CollectFish_Alex CollectFishScript;
    #endregion
    void Awake()
    {
        // REFERENCES //
        Player = GameObject.FindGameObjectWithTag("Player"); // Grabs Player
        CollectFish = GameObject.FindGameObjectWithTag("CollectFish");
        ChickenEnemy = GameObject.FindGameObjectWithTag("Chicken");
        PlayerMovementScript = Player.GetComponent<PlayerMovement>(); // Grabs movement script attached to Player
        CollectFishScript = CollectFish.GetComponent<CollectFish_Alex>();

        // VARIABLES //
        score = 0;
    }
    void Start()
    {
    }

    void Update()
    {
        GameWon();
        // Debug.Log(score);
    }

    public void GameOver()
    {
        // Debug.Log("GameOver");
        PlayerMovementScript.canMove = true;
        FishingMinigame.SetActive(false);
        Destroy(gameObject);
    }
    public void GameWon()
    {
        if (score == 15)
        {
            CollectFishScript.hasFish = true;
            PlayerMovementScript.canMove = true;
            FishingMinigame.SetActive(false);
            ChickenEnemy.SetActive(true);
            Destroy(gameObject);
        }

    }
}
