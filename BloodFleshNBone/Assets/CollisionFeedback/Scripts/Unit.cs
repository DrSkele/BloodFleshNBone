using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class State
{

}

public abstract class Unit : MonoBehaviour, IDamagable
{
    [SerializeField] protected Rigidbody _body;

    [SerializeField] protected int health;
    protected List<State> state = new List<State>();

    public Unit(int healthAmount)
    {
        health = healthAmount;
    }

    protected abstract void OnCollisionEnter(Collision collision);
    protected abstract void OnCollisionStay(Collision collision);
    protected abstract void OnCollisionExit(Collision collision);

    public virtual int Health() => health;

    public virtual void Damage(params Damage[] damages)
    {
        var totalDamage = damages.Select(damage => damage.amount).Aggregate(0, (next, sum) => sum += next);

        health -= totalDamage;
    }
}
