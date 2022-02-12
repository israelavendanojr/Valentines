using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public SO_InventoryItem data { get; private set; }
    public int stackSize { get; private set; }

    public InventorySlot(SO_InventoryItem source)
    {
        data = source;
        AddToStack();
    }
    public void AddToStack()
    {
        stackSize++;
    }
    public void RemoveFromStack()
    {
        stackSize-- ;
    }
}
