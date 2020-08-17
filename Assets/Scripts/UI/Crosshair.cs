using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Image _crosshairImage;
    [SerializeField] private Sprite _invalidSprite;
    
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
        // Note about ? when checking null: If we are only checking it was
        // initialized then we're fine. However it will resolve just fine then throw
        // an NPE if the object has been garbage collected. Avoid NPEs by doing hte explicit
        // != null check, like we are below.
        if (item != null && item.CrosshairDefinition != null)
        {
            Debug.Log($"Crosshair detected {item.CrosshairDefinition}");
            _crosshairImage.sprite = item.CrosshairDefinition.Sprite;
        }
        else
        {
            _crosshairImage.sprite = _invalidSprite;
        }
    }

    // Whenever we save or do a build this gets called
    private void OnValidate()
    {
        _crosshairImage = GetComponent<Image>();
    }
}