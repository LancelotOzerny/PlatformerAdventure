using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/Eat Item")]
public class EatItem : UsableItem
{
    [Space(20)]
    [Header("Recovery Attributes")]
    public int manaRecoveryCount;
    public int hpRecoveryCount;

    public override void Action()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log($"{player.name} + {manaRecoveryCount} mana + {hpRecoveryCount} health");
    }

    public override string GetAttributesInfo()
    {
        string hpRecoveryCountString = hpRecoveryCount > 0 ? $"Восстановление здоровья: {hpRecoveryCount};\n" : "";
        string manaRecoveryCountString = manaRecoveryCount > 0 ? $"Восстановление маны: {manaRecoveryCount};" : "";

        return hpRecoveryCountString + manaRecoveryCountString;
    }
}