using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform currentSpawnpoint;
    [SerializeField] SO_Inventory inventory;
    int itemsNeeded = 9;
    public void SetSpawnpoint(Transform newSpawnpoint)
    {
        currentSpawnpoint = newSpawnpoint;
    }
    public void CheckInventory()
    {
        if (inventory.inventory.Count >= itemsNeeded)
            Debug.Log("Found All Items!");
    }
}
