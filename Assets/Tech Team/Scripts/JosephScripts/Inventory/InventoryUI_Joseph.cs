using UnityEngine;

public class InventoryUI_Joseph : MonoBehaviour
{
    #region Public
    public Transform ItemsParent;
    public GameObject InventoryUI;
    #endregion

    #region Private
    private Inventory_Joseph Inventory;
    private InventorySlot_Joseph[] Slots;
    #endregion

    void Start()
    {
        Inventory = Inventory_Joseph.Instance;
        Inventory.OnItemChangedCallback += UpdateUI;

        Slots = ItemsParent.GetComponentsInChildren<InventorySlot_Joseph>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if(i < Inventory.Items.Count)
            {
                Slots[i].AddItem(Inventory.Items[i]);
            }
            else
            {
                Slots[i].ClearSlot();
            }
        }
    }
}
