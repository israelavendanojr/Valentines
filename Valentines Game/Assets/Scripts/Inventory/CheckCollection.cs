using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollection : MonoBehaviour
{
    GO_Item item;
    void Start()
    {
        item = GetComponent<GO_Item>();
        SO_Inventory inventory = item.Inventory;
        for (int i = 0; i < inventory.inventory.Count; i++)
        {
            if (inventory.inventory[i].data == item.Item)
            {
                gameObject.SetActive(false);
            }

        }
    }

}
