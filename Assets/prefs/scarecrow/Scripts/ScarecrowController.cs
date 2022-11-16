using Unity.VisualScripting;
using UnityEngine;

public class ScarecrowController : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("projectile"))
        {
            _anim.Play("Damaged");
            Destroy(collision.gameObject);
        }
    }

}
