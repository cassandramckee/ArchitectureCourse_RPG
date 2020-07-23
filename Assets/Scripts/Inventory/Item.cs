using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    private bool _wasPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (_wasPickedUp)
            return;

        var inventory = other.GetComponent<Inventory>();

        if (inventory != null)
        {
            inventory.Pickup(this);
            _wasPickedUp = true;
        }
    }

    private void OnValidate()
    {
        // This makes it so that when we add an item we don't have to always
        // make sure that "Is Trigger" is always checked. Makes this automatic
        var collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }
}