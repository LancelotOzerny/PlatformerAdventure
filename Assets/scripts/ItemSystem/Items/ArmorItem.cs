using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/Armor Item")]
public class ArmorItem : Item
{
    [Header("Armor Attributes")]
    public int healthUp;
    public int armorUp;

    public override string GetAttributesInfo()
    {
        string healthUpString = healthUp > 0 ? $"Повышение здоровья: {healthUp};" : "";
        string armorString = armorUp > 0 ? $"Повышение брони: {armorUp};" : "";
        
        return healthUpString + "\n" + armorString;
    }
}
