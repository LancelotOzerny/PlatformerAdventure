using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Upgrade Item")]
public class UpgradeItem : UsableItem
{
    [Space(20)]
    [Header("Upgrade Attributes")]
    public int manaCount;
    public int hpCount;
    public int strengthCount;
    public int abilityCount;

    public override void Action()
    {

    }

    public override string GetAttributesInfo()
    {
        string hpCountString = hpCount > 0 ? $"Повышение здоровья: {hpCount};\n" : "";
        string manaCountString = manaCount > 0 ? $"Повышение маны: {manaCount};\n" : "";
        string strengthCountString = strengthCount > 0 ? $"Повышение силы: {strengthCount};\n" : "";
        string abilityCountString = abilityCount > 0 ? $"Повышение ловкости: {abilityCount};\n" : "";

        return hpCountString + manaCountString + strengthCountString + abilityCountString; 
    }
}