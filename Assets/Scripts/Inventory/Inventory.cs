using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Inventory")]
public class Inventory : ScriptableObject
{
    private Dictionary<Item, int> _inventory = new Dictionary<Item, int>();

    public List<Item> Items;

    public delegate void OnInventoryUpdatedHandler(Item item, int amount);
    public event OnInventoryUpdatedHandler OnInventoryUpdated;

    public int GetItemNumber(Item item)
    {
        return _inventory[item];
    }

    public void UpdateItemCount(Item item)
    {
        if (!_inventory.ContainsKey(item))
            _inventory.Add(item, 0);

        _inventory[item] = _inventory[item] + 1;
        OnInventoryUpdated.Invoke(item, _inventory[item]);
        item.PickUpItem();
    }

    public void ConsumeItem(Item item)
    {
        if (_inventory.ContainsKey(item) && _inventory[item] > 0)
        {
            item.UseItem();
            _inventory[item] = _inventory[item] - 1;
            OnInventoryUpdated.Invoke(item, _inventory[item]);
        }
    }
}
