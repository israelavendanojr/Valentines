using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] SO_Inventory inventory;
    [SerializeField] GameObject itemSlotPrefab;
    public void OnUpdateInventory()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        DrawInventory();
    }

    void DrawInventory()
    {
        for (int i = 0; i < inventory.inventory.Count; i++)
            AddInventorySlot(inventory.inventory[i]);
    }
    void AddInventorySlot(InventorySlot item)
    {
        GameObject itemSlotGO = Instantiate(itemSlotPrefab);
        itemSlotGO.name = item.data.itemName;
        itemSlotGO.transform.SetParent(transform, false);

        UI_ItemSlot slot = itemSlotGO.GetComponent<UI_ItemSlot>();
        slot.Set(item);
    }
    public void Select(UI_ItemSlot item)
    {

    }
}
