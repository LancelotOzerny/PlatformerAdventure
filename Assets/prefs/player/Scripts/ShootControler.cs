using UnityEngine;

public class ShootControler : MonoBehaviour
{
    [SerializeField] private WeaponItem _currentWeapon;
    private SpriteRenderer _sr;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void SetCurrentWeapon(WeaponItem weapon)
    {
        _currentWeapon = weapon;
    }

    private void Shoot()
    {
        if (_currentWeapon != null)
        {
            GameObject bull = Instantiate(_currentWeapon.arrowPrefab);
            bull.transform.position = gameObject.transform.position;
            Destroy(bull, _currentWeapon.distance / 10);
            bull.GetComponent<BullController>().SetDirection(1 * (_sr.flipX ? 1 : -1));
        }
    }
}
