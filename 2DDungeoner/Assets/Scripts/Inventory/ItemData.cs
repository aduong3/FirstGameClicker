using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject {

    public string displayName;
    public Sprite icon;
    public bool isStackable;
    public int currentStackSize;
    public int maxStackSize;
    public bool isNull;
    public int price;
    [TextArea]
    public string description;


    public virtual void Use()
    {
        Player playerScript = GameObject.Find("Player").GetComponent<Player>();
        //Debug.Log($"Using {displayName}");

        if(displayName == "healthPotion")
        {
            playerScript.currentHP += 15;
            if(playerScript.currentHP > playerScript.playerHP)
            {
                float checkPlayerHealth = playerScript.currentHP - playerScript.playerHP;
                playerScript.currentHP -= checkPlayerHealth;
            }
            return;
        }
        else if(displayName == "Jeans")
        {
            Debug.Log("I am Jeans.");
        }
    }
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
