using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBItemMenu_Joseph : MonoBehaviour
{
    #region Public
    public GameObject ButtonPrefab;
    public Transform ContentHolder;
    public TBBattleSystem_Joseph BattleSystem;
    #endregion

    #region Private
    private Inventory_Joseph Inventory = Inventory_Joseph.Instance;
    #endregion

    private void OnEnable()
    {
        for(int i = 0; i < Inventory.Items.Count; i++)
        {
            GameObject temp = Instantiate(ButtonPrefab, ContentHolder);
            temp.GetComponent<Button>().onClick.AddListener(Inventory.Items[i].Use);
            temp.GetComponent<Button>().onClick.AddListener(BattleSystem.OnItemUse);
            temp.transform.GetChild(0).gameObject.GetComponent<Text>().text = Inventory.Items[i].Name;
        }
    }

    private void OnDisable()
    {
        for(int i = 0; i < ContentHolder.transform.childCount; i++)
        {
            Destroy(ContentHolder.transform.GetChild(i).gameObject);
        }
    }
}
