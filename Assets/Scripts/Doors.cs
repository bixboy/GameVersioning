using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Sprite _newSpriteRenderer;

    private bool _isActif = false;
    private bool _inTrigger = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isActif && _inTrigger && Input.GetKeyDown(KeyCode.F))
        {
            OpenDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isActif)
        {
            _inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _isActif)
        {
            _inTrigger = false;
        }
    }

    private void OpenDoor()
    {
        _spriteRenderer.sprite = _newSpriteRenderer;
        _isActif = true;
    }
}
