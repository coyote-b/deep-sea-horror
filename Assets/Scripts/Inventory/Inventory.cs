using System.Collections.Generic;
using TNRD;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Inventory/Inventory")]
public class Inventory : ScriptableObject
{
    private Dictionary<IItem, int> _inventory = new Dictionary<IItem, int>();

    public List<SerializableInterface<IItem>> Items;

    public UnityEvent OnItemAdded;
    public UnityEvent OnItemConsumed;

    public int GetItemNumber(IItem item)
    {
        return _inventory[item];
    }

    public void UpdateItemCount(IItem item)
    {
        _inventory[item] = _inventory[item]++;
    }

    public void ConsumeItem(IItem item)
    {
        if (_inventory.ContainsKey(item) && _inventory[item] > 0)
        {
            item.Use();
            _inventory[item] = _inventory[item]--;
        }
    }
}
