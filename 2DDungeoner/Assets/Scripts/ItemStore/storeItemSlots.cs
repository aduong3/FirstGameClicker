using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class storeItemSlots : MonoBehaviour
{
    public Image icon;
    public ItemData item;
    public TextMeshProUGUI itemText;
    Inventory inventory;
    int cost;
    Player playerScript;

    void Start()
    {
        inventory = Inventory.instance;
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    public void Add(ItemData newItem)
    {
        item = newItem;
        cost = item.price;
        icon.sprite = item.icon;
        itemText.text = $"{item.displayName}<br>{cost} Gold";
        icon.enabled = true;
        itemText.enabled = true;
        
    }

    public void AfterPurchase()
    {
        item = null;
        cost = -1;
        icon.sprite = null;
        itemText.text = "";
        icon.enabled = false;
        itemText.enabled = false;
    }
    
    public void OnPurchase()
    {
        //Debug.Log(item);
        if(item != null){
            if(playerScript.gold >= cost){
                playerScript.gold -= cost;
        inventory.Add(item);
        AfterPurchase();
            }
        }
        
    }
}
