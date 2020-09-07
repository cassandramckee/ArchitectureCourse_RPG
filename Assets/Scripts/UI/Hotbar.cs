using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private Inventory _inventory;
    private Slot[] _slots;
    private Player _playerInput;

    private void OnEnable()
    {
        // Using findObjectOfType for now, will replace with better later
        _playerInput = FindObjectOfType<Player>();
        _playerInput.PlayerInput.HotkeyPressed += HotkeyPressed;
        
        _inventory = FindObjectOfType<Inventory>();
        _inventory.ItemPickedUp += ItemPickedUp;
        _slots = GetComponentsInChildren<Slot>();
    }

    private void HotkeyPressed(int index)
    {
        // Protect ourselves
        if (index >= _slots.Length || index < 0)
            return;
        

        if (_slots[index].IsEmpty == false)
        {
            _inventory.Equip(_slots[index].Item);
        }
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