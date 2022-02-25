using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInventory : MonoBehaviour
{
    [SerializeField] SO_InventoryItem[] items;
    [SerializeField] SO_Inventory inventory;
    [SerializeField] GameEvent inventoryEvent;
    void Start()
    {
        inventory.inventory.Clear();
        for (int i = 0; i < items.Length; i++)
        {
            inventory.Add(items[i]);
            inventoryEvent.Raise();
        }
    }
}

