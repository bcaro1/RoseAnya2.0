using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Element Restoration Item", menuName = "Inventory/ElementRestoreItem")]
public class ElementRestoreItem_Joseph : Item_Joseph
{
    public ElementSlot Element;
    public int ElementRestoreAmount;

    public override void Use()
    {
       switch(Element)
        {
            case ElementSlot.Water:
                StaticDatabase_Joseph.Water += ElementRestoreAmount;
                break;
            case ElementSlot.Wind:
                StaticDatabase_Joseph.Wind += ElementRestoreAmount;
                break;
            case ElementSlot.Earth:
                StaticDatabase_Joseph.Earth += ElementRestoreAmount;
                break;
            case ElementSlot.Fire:
                StaticDatabase_Joseph.Fire += ElementRestoreAmount;
                break;
            case ElementSlot.Health:
                StaticDatabase_Joseph.CurrentHP += ElementRestoreAmount;
                break;
            default:
                break;
        }

        RemoveFromInventory();
    }
}

public enum ElementSlot { Water, Wind, Earth, Fire, Health}
