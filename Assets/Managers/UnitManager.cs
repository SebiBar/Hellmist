using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
UnitManager only handles spawning the player/weapon and the enemies. It does not know anything about the map/objective
only unit management.
 */
public class UnitManager : Singleton<UnitManager>
{
    [SerializeField] private GameObject charactersParent;

    protected override void Awake()
    {
        base.Awake();
        charactersParent = GameObject.Find("Characters");
    }

    public void SpawnPlayer()
    {
        ScriptablePlayer player = ResourceSystem.Instance.GetPlayer(PlayerData.Instance.PlayerClass);
        var spawned = Instantiate(player.Prefab);
        var stats = player.BaseStats;

        spawned.SetStats(stats);
        SetCharactersParent(spawned);
        Debug.Log("UnitManager: Player succesfully spawned");
    }

    public void SpawnEnemy(EnemyType type, Vector2 pos)
    {
        ScriptableEnemy enemy = ResourceSystem.Instance.GetEnemy(type);

        var spawned = Instantiate(enemy.Prefab, pos, Quaternion.identity,transform);

        //Apply possible modifications here such as potion boosts, team synergies, RELIC CHANGES DEBUFFS ETC 
        var stats = enemy.BaseStats;

        spawned.SetStats(stats);
        SetCharactersParent(spawned);
        Debug.Log("UnitManager: Enemy succesfully spaned");
    }

    public void SetCharactersParent(UnitBase unit) => unit.transform.parent = charactersParent.transform;
}
