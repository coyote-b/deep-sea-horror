using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _amountUI;

    public void UpdateUI(int amount)
    {
        _amountUI.text = amount.ToString();
    }
}
