using UnityEngine;

public class CloudsTilemap : MonoBehaviour
{
    [SerializeField] private float _hPos = 0.0f;
    [SerializeField] private float _speed = 1.0f;

    [SerializeField] private float _leftBorder = -100;
    [SerializeField] private float _rightBorder = 80;

    private void Awake()
    {
        transform.position = new Vector2(_hPos, transform.position.y);
    }

    private void Update()
    {
        transform.position = new Vector2(
            transform.position.x - Time.deltaTime * _speed,
            transform.position.y
        );

        if (transform.position.x < _leftBorder)
        {
            transform.position = new Vector2(
                _rightBorder,
                transform.position.y
            );
        }
    }
}
