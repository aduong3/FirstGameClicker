using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public ItemData item;
    //public Equipment equip;
    public Image icon;
    public Image removeButton;
    //Inventory inventory;

    public void AddItem(ItemData newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.enabled = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            item.RemoveFromInventory();
        }

    }

    public void RemoveItem()
    {
        if(item != null)
        {
            item.RemoveFromInventory();
        }
    }
}
