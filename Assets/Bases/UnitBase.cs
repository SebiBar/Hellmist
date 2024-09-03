using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Base of all units. public Stats is a property with private setters. all inheritors will have all the Stats
SetStats(stats) are usually taken from the scriptableobjects in the beginning, handled in unitmanager

TODO: Implement Shroud
 */
public abstract class UnitBase : MonoBehaviour
{
    [SerializeField] protected Stats stats;
    public Stats Stats { get => stats; protected set => stats = value; }
    public int CurrentHealth { get; protected set; }
    public virtual void SetStats(Stats _stats)
    {
        Stats = _stats;
        CurrentHealth = Stats.MaxHealth;
    }
     
    public virtual void TakeDamage(int damage)
    {

        int damageAfterDefense = damage - Stats.Veil;
        damageAfterDefense = Mathf.Max(damageAfterDefense, 0); // Ensure damage is not negative
        CurrentHealth -= damageAfterDefense;
        if (CurrentHealth < 0)
            Die();
    }

    public virtual void Heal(int amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Min(CurrentHealth, Stats.MaxHealth); // Cap health to max value
    }

    protected virtual void Die()
    {
        GameObject.Destroy(this);
    }
}
