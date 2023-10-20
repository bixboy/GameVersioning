using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _knockbackForce;

    private Collider2D _collider;

    private Quaternion faceRightRotation = Quaternion.Euler(0, 0, 0); // Rotation à droite (90 degrés autour de l'axe Z)
    private Quaternion faceLeftRotation = Quaternion.Euler(0, 0, -180); // Rotation à gauche (-90 degrés autour de l'axe Z)

    private Quaternion faceTopRotation = Quaternion.Euler(0, 0, 90); // Rotation à droite (90 degrés autour de l'axe Z)
    private Quaternion faceBottomRotation = Quaternion.Euler(0, 0, -90); // Rotation à gauche (-90 degrés autour de l'axe Z)


    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IDamage damageObject = collider.GetComponent<IDamage>();

        if (damageObject != null)
        {
            Vector3 parentPosition = transform.parent.position;

            Vector2 direction = (Vector2)(collider.gameObject.transform.position - parentPosition).normalized;

            Vector2 knockback = direction * _knockbackForce;

            damageObject.TakeDamage(_damage, knockback);
        } else
        {
            Debug.LogWarning("pas de collider");
        }

    }

    private void Right(bool isFaceRight)
    {
        if (isFaceRight)
        {
            gameObject.transform.rotation = faceRightRotation;
        }
        else 
        {
            gameObject.transform.rotation = faceLeftRotation;

        }
    }

    private void Top(bool isFaceTop)
    {
        if (isFaceTop)
        {
            gameObject.transform.rotation = faceTopRotation;
        }
        else
        {
            gameObject.transform.rotation = faceBottomRotation;

        }
    }
}
