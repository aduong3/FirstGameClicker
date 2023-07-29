using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

[Serializable]
public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public InventorySlot[] slots;

    void Start(){
        inventory = Inventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;
    }

    public void UpdateUI(){
        //Debug.Log(inventory.items.Count);
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].ClearSlot();
            if(i < inventory.items.Count)
            {

                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    public void OnInventoryButton()
    {
        if(gameObject.activeInHierarchy == false)
        {
        gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
