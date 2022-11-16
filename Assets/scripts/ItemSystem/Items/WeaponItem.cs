using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Weapon Item")]
public class WeaponItem : UsableItem
{
    [Space(20)]
    [Header("Weapon Attributes")]
    public int damage;
    public float distance;
    public int frequencyMiss;

    [Header("Projectile Settings")]
    public GameObject arrowPrefab;

    public override string GetAttributesInfo()
    {
        string damageString = damage > 0 ? $"Урон: {damage};" : "";
        string distanceString = distance > 0 ? $"Дистанция: {distance};" : "";
        string frequencyMissString = damage > 0 ? $"Шанс промаха:" : "";

        frequencyMissString += frequencyMiss != 0 & damage > 0 ? $"{System.Math.Round(1 / (double)frequencyMiss, 3)}" : "0.000";

        return damageString + "\n" + distanceString + "\n" + frequencyMissString;
    }

    public override void Action(ItemVisual item)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<ShootControler>().SetCurrentWeapon(this);
    }
}
