using UnityEngine;
using UnityEngine.UI;

public class InventorySlot_Joseph : MonoBehaviour
{
    #region Public
    public Image Icon;
    public Button RemoveButton;
    #endregion

    #region Private
    Item_Joseph Item;
    #endregion

    public void AddItem(Item_Joseph NewItem)
    {
        Item = NewItem;

        Icon.sprite = Item.Icon;
        Icon.enabled = true;
        RemoveButton.interactable = true;
    }

    public void ClearSlot()
    {
        Item = null;
        Icon.sprite = null;
        Icon.enabled = false;
        RemoveButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        //Add Prompt to confirm
        Inventory_Joseph.Instance.Remove(Item);
    }

    public void UseItem()
    {
        if(Item != null)
        {
            Item.Use();
        }
    }
}
