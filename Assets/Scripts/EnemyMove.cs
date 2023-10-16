using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float _speedMove;
    [SerializeField]
    private float _distanceStop;
    [SerializeField]
    private float _areaFocus;

    private GameObject target;

    private void Start()
    {
        target = GameObject.Find("Player");
    }

    void OnDrawGizmos()
    {
        // Dessinez un Gizmo pour visualiser la zone d'attention de l'ennemi
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _areaFocus);
    }

    void Update()
    {
        Transform targetDistance = target.transform;

        float distanceToPlayer = Vector2.Distance(transform.position, targetDistance.position);
        if (distanceToPlayer <= _areaFocus)
        {
            if (distanceToPlayer > _distanceStop)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetDistance.position, _speedMove * Time.deltaTime);
            }
        }
    }
}
