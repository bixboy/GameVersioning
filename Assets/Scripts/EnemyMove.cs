using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float _speedMove;
    [SerializeField]
    private float _distanceStop;
    [SerializeField]
    private float _areaFocus;

    private GameObject _target;

    [SerializeField]
    private int _timeFocused;
    [SerializeField]
    private bool _focused = false;
    private bool _isCoroutineRunning = false;

    private void Start()
    {
        _target = GameObject.Find("Player");
    }

    void OnDrawGizmos()
    {
        // Dessinez un Gizmo pour visualiser la zone d'attention de l'ennemi
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _areaFocus);
    }

    void Update()
    {
        Transform targetDistance = _target.transform;

        float distanceToPlayer = Vector2.Distance(transform.position, targetDistance.position);
        if (distanceToPlayer <= _areaFocus)
        {
            if (!_focused)
            {
                _focused = true;
            }

            if (distanceToPlayer > _distanceStop)
            {
                Vector3 directionToPlayer = targetDistance.position - transform.position;
                directionToPlayer *= -1;
                Quaternion rotationToPlayer = Quaternion.LookRotation(Vector3.forward, directionToPlayer);
                transform.rotation = Quaternion.Euler(0, 0, rotationToPlayer.eulerAngles.z);

                transform.position = Vector2.MoveTowards(transform.position, targetDistance.position, _speedMove * Time.deltaTime);

            }
        }
        else
        {
            if (_focused && !_isCoroutineRunning) 
            {
                StartCoroutine(TimeFocused(_timeFocused));
                _isCoroutineRunning = true;
            }

            if (distanceToPlayer > _distanceStop && _focused)
            {
                // Calculer la direction vers le joueur
                Vector3 directionToPlayer = targetDistance.position - transform.position;
                directionToPlayer *= -1;
                Quaternion rotationToPlayer = Quaternion.LookRotation(Vector3.forward, directionToPlayer);
                transform.rotation = Quaternion.Euler(0, 0, rotationToPlayer.eulerAngles.z);

                transform.position = Vector2.MoveTowards(transform.position, targetDistance.position, _speedMove * Time.deltaTime);
            }
        }
    }

    private IEnumerator TimeFocused(int time)
    {
        yield return new WaitForSeconds(time);
        _focused = false;
        _isCoroutineRunning = false;
    }
}
