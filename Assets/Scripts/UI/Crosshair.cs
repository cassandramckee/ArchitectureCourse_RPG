using System;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Image _crosshairImage;
    [SerializeField] private Sprite _invalidSprite;
    [SerializeField] private Sprite _gunSprite;
    
    private Inventory _inventory;
    

    private void OnEnable()
    {
        _inventory = FindObjectOfType<Inventory>();
        _inventory.ActiveItemChanged += HandleActiveItemChanged;

        // Set up default
        if (_inventory.ActiveItem != null)
            HandleActiveItemChanged(_inventory.ActiveItem);
        else
            _crosshairImage.sprite = _invalidSprite;
    }

    private void HandleActiveItemChanged(Item item)
    {
        if (item == null)
        {
            return;
        }

        // A big problem with this is that game designers have to go ask the programmer
        // to make code changes every time we want a new crosshair. We'll fix this in the
        // next section.
        switch (item.CrosshairMode)
        {
            case CrosshairMode.Gun: 
                _crosshairImage.sprite = _gunSprite;
                break;
            case CrosshairMode.Invalid:
                _crosshairImage.sprite = _invalidSprite;
                break;
        }
        Debug.Log($"Crosshair detected {item.CrosshairMode}");
    }

    // Whenever we save or do a build this gets called
    private void OnValidate()
    {
        _crosshairImage = GetComponent<Image>();
    }
}

// We could have the crosshair sprite be part of the item and let designers set it,
// but because we're not having  hundreds of crosshairs, only a couple, we can just use enum.
// Though designers will still set the crosshair enum on the item.
public enum CrosshairMode
{
    Invalid,
    Gun,
}