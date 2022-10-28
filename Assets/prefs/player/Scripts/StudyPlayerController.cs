using UnityEngine;

namespace Assets.scripts
{
    public class StudyPlayerController : PlayerController
    {
        [SerializeField] private bool _jumpIsAllowed = false;

        protected override void Jump()
        {
            if (_jumpIsAllowed)
            {
                _rb.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
            }
        }
    }
}
