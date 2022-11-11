using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemVisual : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Item _item;
    [SerializeField] private Image img;

    public void Init(Item item)
    {
        _item = item;
        img.sprite = item.itemImage;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInParent<InventoryPanel>().ShowInfo(_item);
    }

    public void OnPointerExit(PointerEventData e)
    {
        GetComponentInParent<InventoryPanel>().HideInfo();
    }
}
