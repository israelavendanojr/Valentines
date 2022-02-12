using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform currentSpawnpoint;
    [SerializeField] SO_Inventory inventory;
    [SerializeField] GameEvent winEvent;
    int itemsNeeded = 9;
    public void SetSpawnpoint(Transform newSpawnpoint)
    {
        currentSpawnpoint = newSpawnpoint;
    }
    public void CheckInventory()
    {
        if (inventory.inventory.Count >= itemsNeeded)
        {
            winEvent.Raise();
            Debug.Log("Found All Items!");
        }
    }
}
