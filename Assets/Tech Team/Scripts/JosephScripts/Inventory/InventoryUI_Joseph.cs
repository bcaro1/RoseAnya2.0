using UnityEngine;
using TMPro;

public class InventoryUI_Joseph : MonoBehaviour
{
    #region Public
    public Transform ItemsParent;
    public GameObject InventoryUI;
    public TextMeshProUGUI DescriptionText;
    public static InventoryUI_Joseph Instance;
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
        UpdateUI();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory"))
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);

            if(InventoryUI.activeSelf)
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                StaticDatabase_Joseph.Item = null;
                DescriptionText.text = "";
                UpdateUI();
            }
            else
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                StaticDatabase_Joseph.Item = null;
                DescriptionText.text = "";
            }
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (i < Inventory.Items.Count)
            {
                Slots[i].AddItem(Inventory.Items[i]);
            }
            else
            {
                Slots[i].ClearSlot();
            }
        }
    }

    public void UseItem()
    {
        Item_Joseph hold = StaticDatabase_Joseph.Item;
        if(hold != null)
        {
            hold.Use();
            DescriptionText.text = "";
            UpdateUI();
        }
    }
}
