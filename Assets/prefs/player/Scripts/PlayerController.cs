using UnityEngine;
using System;
public abstract class PlayerController : MonoBehaviour
{
    protected Rigidbody2D _rb;
    protected Animator _anim;
    protected SpriteRenderer _sr;

    [Header("Player Movement Setting's")]
    [SerializeField] protected float _movementSpeed = 6f;
    [SerializeField] protected float _jumpPower = 24f;
    protected Vector2 _movementDirection;
    public Vector2 MovementDirection { get { return new Vector2(_movementDirection.x, _movementDirection.y); } }

    [Header("Ground Checking")]
    [SerializeField] protected bool isGrounded;
    [SerializeField] protected float _checkRadius = 0.3f;
    [SerializeField] protected float _offsetY = 1.0f;
    [SerializeField] protected LayerMask checkGroundLayerMask;

    protected void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    protected void Start()
    {
        if (_movementSpeed <= 0)
        {
            _movementSpeed = 3.0f;
        }

        if (_jumpPower <= 0)
        {
            _jumpPower = 6.0f;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    protected void Update()
    {
        _movementDirection = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetKey(KeyCode.Space) ? 1 : 0
        );

        _anim.SetBool("isRun", Math.Abs(_movementDirection.x) > 0.05f ? true : false);

        if (isGrounded)
        {
            _anim.SetInteger("JumpStudy", 0);
        }
        else if (!isGrounded)
        {
            if (_rb.velocity.y > 0.5f)
            {
                _anim.SetInteger("JumpStudy", 1);
            }
            else
            {
                _anim.SetInteger("JumpStudy", 2);
            }
        }

        CheckGround();
        CheckFlip();
    }

    protected void FixedUpdate()
    {
        _rb.velocity = new Vector2(_movementDirection.x * _movementSpeed, _rb.velocity.y);
        if (_movementDirection.y > 0 && isGrounded && !Input.GetKey(KeyCode.E))
        {
            Jump();
        }
    }

    protected abstract void Jump();

    protected void CheckFlip()
    {
        bool flipped = false;

        if (_movementDirection.x < 0 && _sr.flipX)
        {
            flipped = true;
        }
        else if (_movementDirection.x > 0 && !_sr.flipX)
        {
            flipped = true;
        }

        if (flipped)
        {
            _sr.flipX = !_sr.flipX;
        }
    }

    protected void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(
            new Vector2(transform.position.x, transform.position.y - _offsetY),
            _checkRadius,
            checkGroundLayerMask
        );

        isGrounded = colliders.Length > 0 ? true : false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(
            new Vector3(
                transform.position.x,
                transform.position.y - _offsetY,
                transform.position.z
            ), 
            _checkRadius);
    }
}
