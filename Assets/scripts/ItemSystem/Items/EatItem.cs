using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/Eat Item")]
public class EatItem : UsableItem
{
    [Space(20)]
    [Header("Recovery Attributes")]
    public int manaRecoveryCount;
    public int hpRecoveryCount;

    public override void Action(ItemVisual item)
    {
        PlayerAttributes _attributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();

        _attributes.Health.MaxValue += hpRecoveryCount;
        _attributes.Health.Add(hpRecoveryCount);

        _attributes.Mana.MaxValue += manaRecoveryCount;
        _attributes.Mana.Add(manaRecoveryCount);

        Destroy(item.gameObject);
    }

    public override string GetAttributesInfo()
    {
        string hpRecoveryCountString = hpRecoveryCount > 0 ? $"Восстановление здоровья: {hpRecoveryCount};\n" : "";
        string manaRecoveryCountString = manaRecoveryCount > 0 ? $"Восстановление маны: {manaRecoveryCount};" : "";

        return hpRecoveryCountString + manaRecoveryCountString;
    }
}