using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private List<ItemUI> _itemUIs;

    private void Start()
    {
        _inventory.OnInventoryUpdated += UpdateItemUI;
    }

    private void UpdateItemUI(Item item, int amount)
    {
        ItemUI itemUI = _itemUIs.Where(x => x.Item == item).FirstOrDefault();

        if (itemUI == null)
            return;

        itemUI.UpdateUI(amount);
    }
}
