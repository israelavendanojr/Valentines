using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class SO_InventoryItem : ScriptableObject
{
    public string itemName;
    [TextArea(5,20)] public string description;
    public Sprite icon;
    public int stackSize;
}
