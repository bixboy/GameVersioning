using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private int _distanceAttack;

    private bool _isAttacking = false;

    [SerializeField]
    private int _damage;
    [SerializeField]
    private int _cooldown;

    private GameObject _target;

    private void Start()
    {
        _target = GameObject.Find("Player");
    }

    private void Update()
    {
        Transform positionPlayer = _target.transform;
        float distanceToPlayer = Vector2.Distance(transform.position, positionPlayer.position);
        if (distanceToPlayer <= _distanceAttack && !_isAttacking)
        {
            Attack(_damage);
            _isAttacking = true;
            StartCoroutine(CooldownAttack(_cooldown));
        }
    }

    private void Attack(int damage)
    {
        PlayerHealth _script = _target.GetComponent<PlayerHealth>();
        _script.TakeDamage(damage);
    }

    private IEnumerator CooldownAttack(int cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        _isAttacking = false;
    }
}
