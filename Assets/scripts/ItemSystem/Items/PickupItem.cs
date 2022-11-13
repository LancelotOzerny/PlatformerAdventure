using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private SpriteRenderer _sr;
    [SerializeField] private Item _item;
    
    [SerializeField] private GameObject _player;
    private bool _playerInside;

    private Vector3 _size;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _sr = GetComponent<SpriteRenderer>();
        Set(_item);
        _size = transform.localScale;
    }

    public void Set(Item item)
    {
        if (item != null)
        {
            _item = item;
            _sr.sprite = _item.itemImage;
        }
    }

    public void Set(ItemVisual item)
    {
        if (item != null)
        {
            _item = item.VisualItem;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && Input.GetKeyDown(KeyCode.W))
        {
            if (_playerInside)
            {
                _player.GetComponent<CharacterInventory>().AddItem(_item);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInside = true;
            transform.localScale = _size * 1.2f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInside = false;
            transform.localScale = _size;
        }
    }

    private void OnDrawGizmos()
    {
        GetComponent<SpriteRenderer>().sprite = _item.itemImage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(
            _player.GetComponent<Collider2D>(),
            GetComponent<Collider2D>()
        );
    }
}
