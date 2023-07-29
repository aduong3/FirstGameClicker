using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentManager : MonoBehaviour
{
#region Singleton
public static EquipmentManager instance;
GameObject equipCurrentPress;
public GameObject[] equipButtons;
Player playerScript;
//StatsPanel statsPanel;

private void Awake() {
    instance = this;
}
#endregion

public Equipment[] currentEquips;
Inventory inventory;
public Image headSlotImage, chestSlotImage, legSlotImage, shoeSlotImage, weaponSlotImage;

private void Start() {
    //statsPanel = GameObject.Find("statsPanel").GetComponent.<StatsPanel>();
    playerScript = GameObject.Find("Player").GetComponent<Player>();
    int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
    currentEquips = new Equipment[numSlots];
    inventory = Inventory.instance;
}

public void Equip(Equipment newItem) {
    {
        int slotIndex = (int) newItem.equipSlot;
        if(currentEquips[slotIndex] != null){
            Equipment oldItem = currentEquips[slotIndex];
            inventory.Add(oldItem);
            RemoveStats(oldItem);
            
        }
        currentEquips[slotIndex] = newItem;
        onEquip(currentEquips[slotIndex]);
        AddStats(currentEquips[slotIndex]);
    }
}

public void onEquip(Equipment item)
{
    if(item.equipSlot.ToString() == "Head"){
    headSlotImage.sprite = item.icon;
    headSlotImage.enabled = true;
    }
    else if(item.equipSlot.ToString() == "Chest"){
    chestSlotImage.sprite = item.icon;
    chestSlotImage.enabled = true;
    }
    else if(item.equipSlot.ToString() == "Legs"){
    legSlotImage.sprite = item.icon;
    legSlotImage.enabled = true;
    }
    else if(item.equipSlot.ToString() == "Shoes"){
    shoeSlotImage.sprite = item.icon;
    shoeSlotImage.enabled = true;
    }
    else if(item.equipSlot.ToString() == "Weapon"){
    weaponSlotImage.sprite = item.icon;
    weaponSlotImage.enabled = true;
    }
}

public void Unequip(int slotIndex)
{
    if(currentEquips[slotIndex] != null)
    {
        Equipment oldItem = currentEquips[slotIndex];
        inventory.Add(oldItem);
        currentEquips[slotIndex] = null;
        RemoveStats(oldItem);
        onUnequip();
    }
}

public void onUnequip(){
    equipCurrentPress = EventSystem.current.currentSelectedGameObject;
    //Debug.Log(equipCurrentPress);
    if(equipCurrentPress == equipButtons[0]){
    headSlotImage.sprite = null;
    headSlotImage.enabled = false;
    }
    else if(equipCurrentPress == equipButtons[1]){
    chestSlotImage.sprite = null;
    chestSlotImage.enabled = false;
    }
    else if(equipCurrentPress == equipButtons[2]){
    legSlotImage.sprite = null;
    legSlotImage.enabled = false;
    }
    else if(equipCurrentPress == equipButtons[3]){
    shoeSlotImage.sprite = null;
    shoeSlotImage.enabled = false;
    }
    else if(equipCurrentPress == equipButtons[4]){
    weaponSlotImage.sprite = null;
    weaponSlotImage.enabled = false;
    }
 
}

public void AddStats(Equipment equip){
    playerScript.strength += equip.strengthModifier;
    playerScript.stamina += equip.staminaModifier;
    playerScript.agility += equip.agilityModifier;
    playerScript.critchance += equip.critModifier;
    StatsPanel.instance.addStat();
}

public void RemoveStats(Equipment equip)
{
    playerScript.strength -= equip.strengthModifier;
    playerScript.stamina -= equip.staminaModifier;
    playerScript.agility -= equip.agilityModifier;
    playerScript.critchance -= equip.critModifier;   
    StatsPanel.instance.addStat(); 
}
}
