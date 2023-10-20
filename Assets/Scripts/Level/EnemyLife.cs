using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour, IDamage
{
    // Field
    [SerializeField, ValidateInput("ValidateMaxHealth")]
    private int _maxHealth;
    [SerializeField]
    private int _currentHealth;

    private Rigidbody2D _enemyRb;
    private Collider2D _physicsCollider;

    private bool _isDie;

    // Properties
    public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public bool Targetable { get { return _targetable; } 
        set {
            _targetable = value;

            if (_isDie)
            {
                _enemyRb.simulated = false;
            }

            _physicsCollider.enabled = value;
        } }

    private bool _targetable = true;


    // Methodes
    #region EditorParametre

    private void Start()
    {
        CurrentHealth = _maxHealth;
        _enemyRb = GetComponent<Rigidbody2D>();
        _physicsCollider = GetComponent<Collider2D>();
    }

    private void Reset()
    {
        Debug.Log("Reset");
        _maxHealth = 100;
    }

    bool ValidateMaxHealth()
    {
        // Guards
        if (_maxHealth <= 0)
        {
            _maxHealth = 100;
            Debug.LogWarning("Pas de HPMax négatif");
            return false;
        }
        return true;
    }

    #endregion


    void Regen(int amount)
    {
        // Guards
        if (amount < 0)
        {
            throw new ArgumentException("Mauvaise valeur, valeur négative");
        }

        if (_isDie)
        {
            return;
        }

        _currentHealth += amount;

        _currentHealth = Math.Clamp(_currentHealth + amount, 0, _maxHealth);

        Debug.Log("Heal");
    }

    public void TakeDamage(int amount)
    {
        // Guards
        if (amount < 0)
        {
            throw new ArgumentException("Mauvaise valeur, valeur négative");
        }

        _currentHealth -= amount;

        _currentHealth = Math.Clamp(_currentHealth - amount, 0, _maxHealth);

        if (_currentHealth <= 0) Die();

        Debug.Log("Damage");
    }

    public void TakeDamage(int damage, Vector2 knockback)
    {
        // Guards
        if (damage < 0)
        {
            throw new ArgumentException("Mauvaise valeur, valeur négative");
        }

        _currentHealth -= damage;

        _enemyRb.AddForce(knockback);

        if (_currentHealth <= 0) Die();

        Debug.Log("Damage");
    }

    void Die()
    {
        _isDie = true;
        _currentHealth = 0;

        Targetable = false;

        Debug.Log("Die");
        Destroy(gameObject);
    }

    [Button] void TakeDamage1() => TakeDamage(10);
    [Button] void Regeneration2() => Regen(5);

}
