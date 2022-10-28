using UnityEngine;

public class CloudsTilemap : MonoBehaviour
{
    [SerializeField] private GameObject player;

    Vector3 _startPos;
    [SerializeField] private Vector2 stepCount = Vector2.one;
    [SerializeField] private Vector2 stepOnDistance = Vector2.one;

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        _startPos = player.transform.position;
    }

    private void Update()
    {
        transform.position = new Vector2 (
            _startPos.x + (_startPos.x - player.transform.position.x) / stepOnDistance.x * stepCount.x,
            _startPos.y + (_startPos.y - player.transform.position.y) / stepOnDistance.y * stepCount.y
        );
    }
}
