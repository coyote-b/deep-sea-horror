using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    [SerializeField]
    private Item _item;

    [SerializeField]
    private TextMeshProUGUI _amountUI;

    public Item Item => _item;

    public void UpdateUI(int amount)
    {
        _amountUI.text = amount.ToString();
    }
}
