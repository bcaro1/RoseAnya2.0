using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup_Joseph : MonoBehaviour
{
    #region Public
    public Item_Joseph Item;
    #endregion

    public void Pickup()
    {
        if(Inventory_Joseph.Instance.Add(Item))
        {
            Destroy(gameObject);
        }
    }
}
