using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public Enemy(int healthAmount): base(healthAmount)
    {

    }

    protected override void OnCollisionEnter(Collision collision)
    {
        var damagable = collision.gameObject.GetComponent<IDamagable>();

        if(damagable != null)
        {
            Debug.Log("Hit!");
            damagable.Damage(new Damage(1, global::Damage.DamageType.Melee, global::Damage.DamageEffect.None));
        }
    }

    protected override void OnCollisionExit(Collision collision)
    {
        
    }

    protected override void OnCollisionStay(Collision collision)
    {
        
    }
}
