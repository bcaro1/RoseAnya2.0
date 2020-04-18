using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Joseph : MonoBehaviour
{
    #region Public
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    public List<Item_Joseph> Items = new List<Item_Joseph>();
    public static Inventory_Joseph Instance;
    public int Space = 15;
    #endregion

    private void Start()
    {
        OnItemChangedCallback += UpdateItemBackup;
        LoadItems();
    }

    private void Update()
    {
        Debug.Log(StaticDatabase_Joseph.Items.Count);
    }


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

    private void UpdateItemBackup()
    {
        StaticDatabase_Joseph.Items.Clear();

        for(int i = 0; i < Items.Count; i++)
        {
            StaticDatabase_Joseph.Items.Add(Items[i]);
        }
    }

    private void LoadItems()
    {
        int hold = StaticDatabase_Joseph.Items.Count;

        for (int i = 0; i < hold; i++)
        {
            Items.Add(StaticDatabase_Joseph.Items[i]);

        }
        OnItemChangedCallback.Invoke();
    }
}
