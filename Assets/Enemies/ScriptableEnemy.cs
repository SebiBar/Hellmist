using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**/
[CreateAssetMenu(fileName = "New Enemy SO")]
public class ScriptableEnemy : ScriptableUnitBase
{
    public EnemyType enemyType;
}

public enum EnemyType
{
    Lost = 0,
    Revenant = 1,
}
