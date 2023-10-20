using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    public bool Targetable { set; get;}

    public void TakeDamage(int damage, Vector2 knockback);
    public void TakeDamage(int damage);

}
