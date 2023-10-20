using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    private bool _isActif = false;
    [SerializeField]
    private int _timeCooldown;
    [SerializeField]
    private int _damage;

    private Animator _animator;
    private GameObject _player;
    private PlayerHealth _playerHealth;

    private bool _playerOnSpikes = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pieds") && !_isActif)
        {
            _isActif = true;
            _playerOnSpikes = true;
            _animator.SetTrigger("OnSpike");

            _player = collision.gameObject;
            _playerHealth = _player.GetComponent<PlayerHealth>();

            StartCoroutine(CooldownSpike(_timeCooldown));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pieds") && _isActif)
        {
            _playerOnSpikes = false;
        }
    }

    public void InflictDamage()
    {
        if (_playerOnSpikes)
        {
            // Infliger des d�g�ts au joueur
            _playerHealth.TakeDamage(_damage);
        }
    }

    private IEnumerator CooldownSpike(int timeCooldown)
    {
        yield return new WaitForSeconds(timeCooldown);
        _isActif = false;
    }
}
