using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasentSlime03 : MonoBehaviour
{
    public int inventoryIncrease = 1;
    private string peasantTag = "Selectable";

    void Start()
    {
        GameObject[] allPeasants = GameObject.FindGameObjectsWithTag(peasantTag);
        foreach (GameObject peasant in allPeasants)
        {
            InventoryManager inventoryManager = peasant.GetComponent<InventoryManager>();
            if (inventoryManager != null)
            {
                inventoryManager.maxItemsInInventory += inventoryIncrease;
            }
        }
    }
}
