﻿using System.Collections.Generic;
using NSubstitute.Core;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private Inventory _inventory;
    private Slot[] _slots;

    private void OnEnable()
    {
        // Using findObjectOfType for now
        _inventory = FindObjectOfType<Inventory>();
        _inventory.ItemPickedUp += ItemPickedUp;
        _slots = GetComponentsInChildren<Slot>();
    }

    private void ItemPickedUp(Item item)
    {
        Slot slot = FindNextOpenSlot();
        if (slot != null)
        {
            slot.SetItem(item);
        }
    }

    private Slot FindNextOpenSlot()
    {
        foreach (Slot slot in _slots)
        {
            if (slot.IsEmpty)
            {
                return slot;
            }
        }
        return null;
    }
}