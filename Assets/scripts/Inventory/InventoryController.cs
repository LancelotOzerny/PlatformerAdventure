using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    [SerializeField] private KeyCode _key = KeyCode.I;

    [SerializeField] private int _itemsCount = 30;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            _inventory.SetActive(!_inventory.activeSelf);
            Cursor.visible = _inventory.activeSelf;
        }
    }
}
