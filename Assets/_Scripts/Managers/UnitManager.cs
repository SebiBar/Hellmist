using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : Singleton<UnitManager>
{
    public void SpawnPlayer()
    {
        Debug.Log("SpawnPlayer");
        ScriptablePlayer player = ResourceSystem.Instance.GetPlayer(PlayerData.Instance.PlayerClass);
        Instantiate(player.Prefab);
    }

    public void SpawnEnemy(EnemyType type, Vector2 pos)
    {
        var enemyScriptable = ResourceSystem.Instance.GetEnemy(type);

        var spawned = Instantiate(enemyScriptable.Prefab, pos, Quaternion.identity,transform);

        //Apply possible modifications here such as potion boosts, team synergies, RELIC CHANGES DEBUFFS ETC 
        var stats = enemyScriptable.BaseStats;

        spawned.SetStats(stats);
    }
}
