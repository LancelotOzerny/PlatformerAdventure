using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalController : MonoBehaviour
{
    [SerializeField] private GameObject _journal;

    void Start()
    {
        _journal.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _journal.SetActive(!_journal.activeSelf);
        }
    }
}
