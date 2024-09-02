using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
Base class for scriptable enemies/players. BaseStats is a property. _stats is the field.
Also has the stats defined

TODO: Add Shroud (Shield)
 */
public abstract class ScriptableUnitBase : ScriptableObject
{
    [SerializeField] private Stats _stats;
    public Stats BaseStats => _stats;

    public UnitBase Prefab;
}

[Serializable]
public struct Stats
{
    public int MaxHealth;
    public int Veil;
    public int AttackPower;
    public int MovementSpeed;
}