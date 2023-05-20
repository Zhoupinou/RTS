using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType 
{
    None,
    Iron,
    Gold,
    Food
}
public class InventoryManager : MonoBehaviour
{
    public int itemsInInventory = 0;
    public int maxItemsInInventory = 10;
    public itemType itemType;

}
