using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private Vector3 _scale;
    private bool _isEntered;

    private InventoryController _inventory;
    private Sprite _icon;
    private string _itemName;

    public string ItemName { get { return _itemName; } }
    public Sprite IconSprite { get { return _icon; } }

    // Start is called before the first frame update
    void Start()
    {
        _scale = transform.localScale;
        _isEntered = false;
        _icon = GetComponent<SpriteRenderer>().sprite;

        _inventory = GameObject.FindGameObjectWithTag("UIController").GetComponent<InventoryController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && Input.GetKeyDown(KeyCode.W) && _isEntered)
        {
            _inventory.Add(GetComponent<ItemController>());
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // или по тегу смотреть collision.gameObject.tag
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            transform.localScale = _scale * 1.2f;
            _isEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.localScale = _scale;
            _isEntered = false;
        }
    }
}
