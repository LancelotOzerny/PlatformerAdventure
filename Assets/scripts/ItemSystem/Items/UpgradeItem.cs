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

    public override void Action(ItemVisual item)
    {
        PlayerAttributes _attributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();

        _attributes.Health.MaxValue += hpCount;
        _attributes.Health.Add(hpCount);

        _attributes.Mana.MaxValue += manaCount;
        _attributes.Mana.Add(manaCount);

        _attributes.Strength.MaxValue += strengthCount;
        _attributes.Strength.Add(strengthCount);

        _attributes.Ability.MaxValue += abilityCount;
        _attributes.Ability.Add(abilityCount);

        Destroy(item.gameObject);
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