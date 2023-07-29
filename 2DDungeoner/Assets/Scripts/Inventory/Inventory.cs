using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    public List<ItemData> items = new List<ItemData>();
    [SerializeField] private int space;

#region Singleton
    public static Inventory instance;

    private void Awake() {
        if(instance != null){
        Debug.LogWarning("More than 1 instance of inventory");
        }
        instance = this;
    }

    #endregion

    public void Add(ItemData item)
    {
        if(items.Count >= space){
            Debug.Log("No space to add items.");
            return;
        }
        items.Add(item);
        if(OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }

        
    }
    
    public void Remove(ItemData item)
    {

        items.Remove(item);
        if(OnItemChangedCallback != null)
        {
           OnItemChangedCallback.Invoke();
        }
        
    }
}
