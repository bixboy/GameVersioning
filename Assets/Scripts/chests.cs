using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chests : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Sprite _newSpriteRenderer;
    [SerializeField]
    private GameObject _textChests;
    [SerializeField]
    private bool _isActif = false;
    [SerializeField]
    private bool _inTrigger = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnInteraction()

    {

        if (!_isActif && _inTrigger)
        {
            OpenChest();
            Debug.Log("Open Chest");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isActif)
        {
            _textChests.SetActive(true);
            _inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _textChests.SetActive(false);
            _inTrigger = false;
        }
    }

    private void OpenChest()
    {
        _spriteRenderer.sprite = _newSpriteRenderer;

        _textChests.SetActive(false);
        _isActif = true;
    }
}
