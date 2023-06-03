using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{
    None,
    Iron,
    Gold,
    Wood,
    Food
}
public class InventoryManager : MonoBehaviour
{
    public int itemsInInventory = 0;
    public int maxItemsInInventory = 10;
    public ItemType itemType;

    public List<ItemType> itemTypes;


}
