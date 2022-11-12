using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    public GameObject InventoryPanelVisual;
    public CharacterInventory inventory;
    public Transform inventoryItemsPanel;

    public GameObject itemVisualPrefab;

    [Header("Information Fields")]
    [SerializeField] private Text _itemNameField;
    [SerializeField] private Text _itemDescriptionField;
    [SerializeField] private Image _itemIconField;
    [SerializeField] private Image _itemIconBorder;

    private void Start()
    {
        HideInfo();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ChangeInventoryActive();
        }
    }

    public void ChangeInventoryActive()
    {
        InventoryPanelVisual.SetActive(!InventoryPanelVisual.activeSelf);
        Cursor.visible = InventoryPanelVisual.activeSelf;
    }

    public void AddItem(Item item)
    {
        GameObject newItem = Instantiate(itemVisualPrefab, Vector3.zero, Quaternion.identity, inventoryItemsPanel);
        newItem.GetComponent<ItemVisual>().Init(item);
    }

    public void ShowInfo(Item item)
    {
        _itemIconBorder.enabled = true;
        _itemNameField.enabled = true;
        _itemDescriptionField.enabled = true;
        _itemIconField.enabled = true;

        _itemNameField.text += item.itemName;
        _itemDescriptionField.text = item.itemDescription + "\n\n" + item.GetAttributesInfo();
        _itemIconField.sprite = item.itemImage;
    }

    public void HideInfo()
    {
        _itemIconBorder.enabled = false;
        _itemNameField.enabled = false;
        _itemDescriptionField.enabled = false;
        _itemIconField.enabled = false;

        _itemNameField.text = string.Empty;
        _itemDescriptionField.text = string.Empty;
        _itemIconField.sprite = null;
    }
}
