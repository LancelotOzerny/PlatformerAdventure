using UnityEngine;

namespace Assets.scripts
{
    public class CameraFollowController : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private PlayerController _playerController;

        [SerializeField] private float _followSpeed = 2.0f;
        [SerializeField] private Vector2 _offset;

        private void Awake()
        {
            if (_player == null)
            {
                _player = GameObject.FindGameObjectWithTag("Player");
            }
            _playerController = _player.GetComponent<PlayerController>();

            transform.position = new Vector3(
                _player.transform.position.x,
                _player.transform.position.y,
                transform.position.z
            ); 
        }

        private void Update()
        {
            if (_player != null)
            {
                if (
                    (_playerController.MovementDirection.x < 0 && _offset.x > 0) |
                    (_playerController.MovementDirection.x > 0 && _offset.x < 0)
                ) {
                    _offset.x *= -1;
                }

                transform.position = Vector3.Lerp(
                    transform.position, 
                    new Vector3(
                        _player.transform.position.x + _offset.x,
                        _player.transform.position.y + _offset.y,
                        transform.position.z
                    ),
                    _followSpeed * Time.deltaTime);
            }
        }
    }
}
