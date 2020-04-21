using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item_Joseph : ScriptableObject
{
    public string Name = "New Item";
    public string Description = "This is a new Item";
    public Sprite Icon = null;
    
    public virtual void Use()
    {
        //Use the Item
        StaticDatabase_Joseph.CurrentHP += 20;
        //RemoveFromInventory();
    }

    public void RemoveFromInventory()
    {
        Inventory_Joseph.Instance.Remove(this);
        InventoryUI_Joseph.Instance.UpdateUI();
    }
}
