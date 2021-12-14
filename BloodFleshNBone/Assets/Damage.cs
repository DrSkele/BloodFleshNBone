using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IDamagable
{
    public int Health();
    public void Damage(params Damage[] damages);
}
public class Damage
{
    public enum DamageType { None, Melee, Ranged }

    public enum DamageEffect { None, }

    public DamageType type;
    public DamageEffect effect;
    public int amount;

    public Damage(int amount, DamageType type = DamageType.None, DamageEffect effect = DamageEffect.None)
    {
        this.amount = amount;
        this.type = type;
        this.effect = effect;
    }
}