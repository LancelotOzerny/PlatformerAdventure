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
        string hpCountString = hpCount > 0 ? $"��������� ��������: {hpCount};\n" : "";
        string manaCountString = manaCount > 0 ? $"��������� ����: {manaCount};\n" : "";
        string strengthCountString = strengthCount > 0 ? $"��������� ����: {strengthCount};\n" : "";
        string abilityCountString = abilityCount > 0 ? $"��������� ��������: {abilityCount};\n" : "";

        return hpCountString + manaCountString + strengthCountString + abilityCountString; 
    }
}