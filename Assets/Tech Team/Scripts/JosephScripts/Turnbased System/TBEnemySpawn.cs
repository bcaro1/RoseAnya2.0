using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBEnemySpawn : MonoBehaviour
{
    public GameObject BattleSystem;
    public GameObject Enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StaticDatabase_Joseph.Enemy = Enemy;
            Instantiate(BattleSystem);
            Destroy(gameObject);
        }
    }
}
