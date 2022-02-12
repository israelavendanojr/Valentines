using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class SO_Inventory : ScriptableObject
{
    private Dictionary<SO_InventoryItem, InventorySlot> itemDictionary = new Dictionary<SO_InventoryItem, InventorySlot>();
    public List<InventorySlot> inventory = new List<InventorySlot>();
    public void Add(SO_InventoryItem referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventorySlot value))
            value.AddToStack();
        else
        {
            InventorySlot newItem = new InventorySlot(referenceData);
            inventory.Add(newItem);
            itemDictionary.Add(referenceData, newItem);
        }
    }
    public void Remove(SO_InventoryItem referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventorySlot value))
        {
            value.RemoveFromStack();

            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                itemDictionary.Remove(referenceData);
            }
        }
    }
}
