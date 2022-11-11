using UnityEngine;


[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Weapon,
        Clothes,
        UsableItem,
        QuestItem
    }

    public enum WeaponType
    {
        TwoHands,
        OneHands,
        Shield
    }

    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public ItemType itemType;
    public WeaponType weaponType;
}
