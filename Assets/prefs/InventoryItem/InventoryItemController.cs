using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    [SerializeField] private Image _img;
    private string _itemName;

    public void Set(ItemController item)
    {
        _itemName = item.ItemName;
        _img.sprite = item.IconSprite;
    }
}
