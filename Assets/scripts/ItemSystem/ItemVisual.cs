using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ItemVisual : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Item _item;
    [SerializeField] private Image img;
    public Item VisualItem { get { return _item; } }

    public void Init(Item item)
    {
        _item = item;
        img.sprite = item.itemImage;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInParent<InventoryPanel>().ShowInfo(this);
    }

    public void OnPointerExit(PointerEventData e)
    {
        GetComponentInParent<InventoryPanel>().HideInfo();
    }
}
