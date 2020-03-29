using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveManager_Alex : MonoBehaviour
{
    #region Public
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Door;
    #endregion
    #region Private

    #endregion


    void Awake()
    {

    }

    void Update()
    {
        if (Enemy1 == null && Enemy2 == null)
        {
            Door.SetActive(false);
        }
    }
}
