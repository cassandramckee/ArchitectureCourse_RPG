using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class Slot : MonoBehaviour
{
    [FormerlySerializedAs("_icon")] [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _text;
    public Item Item { get; private set; }
    public bool IsEmpty => Item == null;
    public Image IconImage => _iconImage;

    public void SetItem(Item item)
    {
        Item = item;
        _iconImage.sprite = item.Icon;
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