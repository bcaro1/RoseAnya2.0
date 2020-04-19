using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot_Joseph : MonoBehaviour
{
    #region Public
    public Image Icon;
    public Button RemoveButton;
    public TextMeshProUGUI DescriptionText;
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
        ClearSlot();
    }

    public void focusItem()
    {
        if (Item != null)
        {
            StaticDatabase_Joseph.Item = Item;
            DescriptionText.text = Item.Name + " - " + Item.Description;
        }
    }
}
