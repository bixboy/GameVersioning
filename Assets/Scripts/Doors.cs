using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Doors : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Sprite _newSpriteRenderer;
    [SerializeField]
    private GameObject _textDoors;
    [SerializeField]
    private BoxCollider2D _boxCollider;
    [SerializeField]
    private PolygonCollider2D _polygonCollider;
    [SerializeField]
    private bool _isActif = false;
    [SerializeField]
    private bool _inTrigger = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _polygonCollider = GetComponent <PolygonCollider2D>();
    }

    void OnInteraction()
    {
        if (!_isActif && _inTrigger)
        {
            OpenDoor();
            Debug.Log("Open Door");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isActif)
        {
            _textDoors.SetActive(true);
            _inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _textDoors.SetActive(false);
            _inTrigger = false;
        }
    }

    private void OpenDoor()
    {
        _spriteRenderer.sprite = _newSpriteRenderer;
        _polygonCollider.enabled = true;
        _boxCollider.enabled = false;
        _isActif = true;
    }
}
