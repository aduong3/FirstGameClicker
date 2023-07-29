using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{

    public List<ItemData> itemsInStore = new();
    [SerializeField] storeItemSlots[] slots;

    [SerializeField] private int[] table;


public void openStore(){

    if(gameObject.activeInHierarchy == true){
        gameObject.SetActive(false);
    }
    else{
    gameObject.SetActive(true);
    PopulateStore();
    }
}

    public void PopulateStore()
    {
        for(int i = 0; i < slots.Length; i++)
        {
           /*  if(slots[i].item == null){
            int randomNumber = Random.Range(0,itemsInStore.Count);
            slots[i].Add(itemsInStore[randomNumber]);
            } */
                    int total = 0;
        foreach(var item in table)
        {
            total += item;
        }
        int randomNumber = Random.Range(0,total);
        for(int j = 0; j < table.Length; j++){
        if(randomNumber <= table[j])
        {
            if(slots[i].item == null){
                slots[i].Add(itemsInStore[j]);
            }
            }
        
        else
        {
            randomNumber -= table[j];
        }
    }
        }


    } 






//equipCurrentPress = EventSystem.current.currentSelectedGameObject;
}
