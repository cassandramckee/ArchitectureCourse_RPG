using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    [SerializeField] private CrosshairDefinition _crosshairDefinition;
    [SerializeField] private UseAction[] _actions = new UseAction[0];
    [SerializeField] private Sprite _icon;
    
    // A getter that's a way of preventing others from editing actions in code.
    // aka a read only property
    public CrosshairDefinition CrosshairDefinition => _crosshairDefinition;
    public UseAction[] Actions => _actions;
    public Sprite Icon => _icon;
    
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