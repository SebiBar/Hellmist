using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ScriptableUnitBase : ScriptableObject
{
    public Faction faction;

    [SerializeField] private Stats _stats;
    public Stats BaseStats => _stats;

    public UnitBase Prefab;
}

[Serializable]
public struct Stats
{
    public int MaxHealth;
    public int AttackPower;
    public int MovementSpeed;
}

[Serializable]
public enum Faction
{
    Player = 0,
    Enemy = 1,
}