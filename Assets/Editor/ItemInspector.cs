using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEditor;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using System.Drawing.Printing;

[CustomEditor(typeof(Item))]
public class ItemInspector : Editor
{
    public override void OnInspectorGUI()
    {
        Item _currentItem = (Item)target;

        // Имя предмета
        string newItemName = EditorGUILayout.TextField("Item Name", _currentItem.itemName);
        _currentItem.itemName = newItemName;
        
        // Описание предмета
        string newItemDescription = EditorGUILayout.TextField("Item Description", _currentItem.itemDescription);
        _currentItem.itemDescription = newItemDescription;

        _currentItem.itemImage = (Sprite)EditorGUILayout.ObjectField(
            _currentItem.itemImage, 
            typeof(Sprite),
            GUILayout.Width(150),
            GUILayout.Height(150)
        );

        _currentItem.itemType = (Item.ItemType)EditorGUILayout.EnumPopup("Item Type", _currentItem.itemType);

        if (_currentItem.itemType == Item.ItemType.Weapon)
        {
            _currentItem.weaponType = (Item.WeaponType)EditorGUILayout.EnumPopup("Item Type", _currentItem.weaponType);
        }
    }
}
