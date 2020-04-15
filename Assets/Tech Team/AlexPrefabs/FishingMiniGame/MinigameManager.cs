using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinigameManager : MonoBehaviour
{
    #region Public
    public GameObject FishingMinigame;
    public PlayerMovement PlayerMovementScript;
    public GameObject Player;
    public static int score = 0;
    #endregion
    void Awake()
    {
        // REFERENCES //
        Player = GameObject.FindGameObjectWithTag("Player"); // Grabs Player
        PlayerMovementScript = Player.GetComponent<PlayerMovement>(); // Grabs movement script attached to Player

        // VARIABLES //
        score = 0;
    }
    void Start()
    {
    }

    void Update()
    {
        Debug.Log(score);
        GameWon();
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        PlayerMovementScript.canMove = true;
        FishingMinigame.SetActive(false);
        Destroy(gameObject);
    }
    public void GameWon()
    {
        if (score == 15)
        {
            Debug.Log("Give fish");
            PlayerMovementScript.canMove = true;
            FishingMinigame.SetActive(false);
            Destroy(gameObject);
        }

    }
}
