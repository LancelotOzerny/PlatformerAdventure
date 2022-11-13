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

    [Header("Item Prefab")]
    [SerializeField] private GameObject _itemPrefab;
    private ItemVisual _currentItem = null;

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

        if (Input.GetKeyDown(KeyCode.R) && InventoryPanelVisual.activeSelf && _currentItem)
        {
            GameObject obj = Instantiate(_itemPrefab);
            obj.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            obj.GetComponent<PickupItem>().Set(_currentItem);
            Destroy(_currentItem.gameObject);
            HideInfo();
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

    public void ShowInfo(ItemVisual item)
    {
        _currentItem = item;

        _itemIconBorder.enabled = true;
        _itemNameField.enabled = true;
        _itemDescriptionField.enabled = true;
        _itemIconField.enabled = true;

        _itemNameField.text += item.VisualItem.itemName;
        _itemDescriptionField.text = item.VisualItem.itemDescription + "\n\n" + item.VisualItem.GetAttributesInfo();
        _itemIconField.sprite = item.VisualItem.itemImage;
    }

    public void HideInfo()
    {
        _currentItem = null;

        _itemIconBorder.enabled = false;
        _itemNameField.enabled = false;
        _itemDescriptionField.enabled = false;
        _itemIconField.enabled = false;

        _itemNameField.text = string.Empty;
        _itemDescriptionField.text = string.Empty;
        _itemIconField.sprite = null;
    }
}
