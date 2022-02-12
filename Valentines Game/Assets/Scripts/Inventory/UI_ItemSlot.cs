using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_ItemSlot : MonoBehaviour
{
    Image icon;
    public string itemName, description;
    private void Awake()
    {
        icon = transform.Find("Icon").GetComponentInChildren<Image>();
    }
    public void Set(InventorySlot item)
    {
        icon.sprite = item.data.icon;
        itemName = item.data.itemName;
        description = item.data.description;
    }
}
