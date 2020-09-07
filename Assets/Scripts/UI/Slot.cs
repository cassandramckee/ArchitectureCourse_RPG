using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _text;
    public Item Item { get; private set; }
    public bool IsEmpty => Item == null;

    public void SetItem(Item item)
    {
        Item = item;
        _icon.sprite = item.Icon;
    }

    // Sets things up automagically in the unity editor
    private void OnValidate()
    {
        int hotkeyNumber = transform.GetSiblingIndex() + 1;
        _text = GetComponentInChildren<TMP_Text>();
        _text.SetText(hotkeyNumber.ToString());
        gameObject.name = "Slot " + hotkeyNumber;
    }
}