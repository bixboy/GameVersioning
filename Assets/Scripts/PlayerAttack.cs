using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject _attackArea = default;

    [SerializeField]
    private bool _attacking = false;

    [SerializeField]
    private float timeCooldown;

    private void Start()
    {
        _attackArea = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
 
    }

    private void Attack()
    {
        _attacking = true;
        if (_attacking)
        {
            StartCoroutine(Cooldown(timeCooldown));
            _attackArea.SetActive(_attacking);
        }

    }

    private IEnumerator Cooldown(float timeCooldown)
    {
        yield return new WaitForSeconds(timeCooldown);
        _attacking = false;
        _attackArea.SetActive(_attacking);

    }

}
