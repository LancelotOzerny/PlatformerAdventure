using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportator : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private int _sceneIndex = 0;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _anim.SetBool("teleportation", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _anim.SetBool("teleportation", false);
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}
