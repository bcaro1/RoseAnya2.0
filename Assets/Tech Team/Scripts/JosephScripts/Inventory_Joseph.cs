using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Joseph : MonoBehaviour
{
    #region Public
    public List<Item_Joseph> Items = new List<Item_Joseph>();
    public static Inventory_Joseph Instance;
    public int Space = 20;
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    #endregion

    private void Awake()
    {
        if(Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public bool Add(Item_Joseph Item)
    {
        if(Items.Count >= Space)
        {
            return false;
        }
        Items.Add(Item);

        if(OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item_Joseph Item)
    {
        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
        Items.Remove(Item);
    }
}
