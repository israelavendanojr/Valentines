using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GO_Item : MonoBehaviour, IInteractable
{
    [SerializeField] SO_InventoryItem item;
    [SerializeField] SO_Inventory inventory;
    [SerializeField] UnityEvent inventoryEvent;
    [SerializeField] SimpleAudioEvent pickupSfx;
    public SO_Inventory Inventory { get { return inventory; } }
    public SO_InventoryItem Item { get { return item; } }

    public void ReceiveItem()
    {
        inventory.Add(item);
        pickupSfx.Play();
        inventoryEvent.Invoke();
        Destroy(gameObject);
    }
    public void Interact()
    {
        ReceiveItem();
    }
}
