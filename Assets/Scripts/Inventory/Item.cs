using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    [SerializeField] private UseAction[] _actions;
    // A getter that's a way of preventing others from editing actions in code.
    public UseAction[] Actions => _actions;
    
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