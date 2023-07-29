using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equips", menuName = "Inventory/Equips")]
public class Equipment : ItemData
{
    public EquipmentSlot equipSlot;
    public float strengthModifier;
    public float staminaModifier;
    public float agilityModifier;
    public float critModifier;



    public override void Use(){
        EquipmentManager.instance.Equip(this);
    }

}
    public enum EquipmentSlot { Head, Chest, Legs, Shoes, Weapon }

