using UnityEngine;



public abstract class Item : ScriptableObject
{
    [Header("Base Item Attributes")]
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;

    public abstract string GetAttributesInfo();
}
