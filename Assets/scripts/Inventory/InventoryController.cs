using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private GameObject _inventoryItemPref;
    [SerializeField] private KeyCode _key = KeyCode.I;

    [SerializeField] private int _itemsCount = 30;

    [SerializeField] private List<ItemController> _items;

    private void Awake()
    {
        _items = new List<ItemController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            _inventory.SetActive(!_inventory.activeSelf);
            Cursor.visible = _inventory.activeSelf;
        }
    }

    public void Add(ItemController item)
    {
        _items.Add(item);

        GameObject obj = Instantiate(_inventoryItemPref, _inventory.transform);
        obj.GetComponent<InventoryItemController>().Set(item);

        Destroy(item.GetComponent<GameObject>());
    }
}
