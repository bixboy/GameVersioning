using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Sprite _newSpriteRenderer;

    [SerializeField]
    GameObject GameManager;
    [SerializeField]
    private ReloadManager _reloadManager;

    private bool _isActif = false;

    private void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _reloadManager = GameManager.GetComponent<ReloadManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isActif)
        {
            Vector3 _player = collision.transform.position;
            _reloadManager.SetCheckpoint(_player);

            _spriteRenderer.sprite = _newSpriteRenderer;
            _isActif = true;
        }
    }
}
