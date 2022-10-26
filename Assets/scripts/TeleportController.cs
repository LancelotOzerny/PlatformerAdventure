using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private Transform _newPlace;
    [SerializeField] private List<string> _tags;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string tag in _tags)
        {
            if (collision.CompareTag(tag))
            {
                Teleport(collision.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string tag in _tags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                Teleport(collision.gameObject);
            }
        }
    }

    private void Teleport(GameObject obj)
    {
        if (_newPlace != null)
        {
            obj.transform.position = new Vector2(_newPlace.position.x, _newPlace.position.y);

            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}
