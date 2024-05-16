using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public event Action OnItemPickedUp;
    public event Action OnItemUsed;

    [SerializeField]
    private string _description;

    public void PickUpItem()
    {
        OnItemPickedUp.Invoke();
    }

    public void UseItem()
    {
        OnItemUsed.Invoke();
    }
}
