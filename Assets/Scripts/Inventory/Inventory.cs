using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Our events
    public event Action<Item> ActiveItemChanged;
    public event Action<Item> ItemPickedUp;

    
    [SerializeField] private Transform _rightHand;

    private List<Item> _items = new List<Item>();
    private Transform _itemRoot;
    
    public Item ActiveItem { get; private set; }

    private void Awake()
    {
        _itemRoot = new GameObject("Items").transform;
        _itemRoot.transform.SetParent(transform);
    }

    public void Pickup(Item item)
    {
        _items.Add(item);
        item.transform.SetParent(_itemRoot);
        ItemPickedUp?.Invoke(item);

        Equip(item);
    }

    public void Equip(Item item)
    {
        // Likely puts item in right spot, fires a bunch of call backs, etc. 
        Debug.Log($"Equipped Item {item.gameObject.name}");
        item.transform.SetParent(_rightHand);
        // Note: Performance impact here is fine since we've only done it once.
        // If doing repeatedly, cache the value and go from there.
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        ActiveItem = item;
        // If ActiveItem is not null (the ? part) then invoke the event and pass in what the active item is
        // The ? is similar to "if (ActiveItem != null)"
        ActiveItemChanged?.Invoke(ActiveItem);
    }


}