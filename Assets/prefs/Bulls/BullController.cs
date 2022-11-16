using UnityEngine;

public class BullController : MonoBehaviour
{
    private int _hDirection = 1;
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(int value)
    {
        _hDirection = value;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_hDirection * _moveSpeed, _rb.velocity.y);
    }
}
