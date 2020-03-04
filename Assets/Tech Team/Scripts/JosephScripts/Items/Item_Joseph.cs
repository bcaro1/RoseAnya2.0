using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item_Joseph : ScriptableObject
{
    public string Name = "New Item";
    public string Description = "This is a new Item";
    public Sprite Icon = null;
    
    public virtual void Use()
    {
        //Use the Item
    }

    public void RemoveFromInventory()
    {
        Inventory_Joseph.Instance.Remove(this);
    }
}
