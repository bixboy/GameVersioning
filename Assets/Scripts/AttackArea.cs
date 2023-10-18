using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField]
    private int _damage;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<EnemyLife>() != null) 
        {

            EnemyLife enemyLife = collider.GetComponent<EnemyLife>();
            enemyLife.TakeDamage(_damage);

        }
    }
}
