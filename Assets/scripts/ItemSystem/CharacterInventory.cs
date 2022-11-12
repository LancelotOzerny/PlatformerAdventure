using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public Item[] startItems;
    public InventoryPanel inventoryVisual;

    private List<Item> _inventoryItems = new List<Item>();

    private void Start()
    {
        foreach (Item item in startItems)
        {
            AddItem(item);
        }    
    }

    public void AddItem(Item item)
    {
        _inventoryItems.Add(item);
        inventoryVisual.AddItem(item);
    }
}
