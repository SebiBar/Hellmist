using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// General repository for all scriptable objects
public class ResourceSystem : Singleton<ResourceSystem>
{
    public List<ScriptableEnemy> Enemies {  get; private set; }
    public Dictionary<EnemyType, ScriptableEnemy> _EnemiesDict; // Allows for only 1 of each type of enemy

    public List<ScriptablePlayer> Players { get; private set; }
    public Dictionary<PlayerClassType, ScriptablePlayer> _PlayersDict;

    protected override void Awake()
    {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources()
    {
        Enemies = Resources.LoadAll<ScriptableEnemy>("Enemies").ToList();
        _EnemiesDict = Enemies.ToDictionary(obj => obj.enemyType, obj => obj); // dictionary is (key:value)

        Players = Resources.LoadAll<ScriptablePlayer>("Players").ToList();
        _PlayersDict = Players.ToDictionary(obj => obj.playerClassType, obj => obj);

    }

    public ScriptableEnemy GetEnemy(EnemyType enemyType) => _EnemiesDict[enemyType];
    //public ScriptableEnemy GetRandomEnemy() => Enemies[Random.Range(0, Enemies.Count)];

    public ScriptablePlayer GetPlayer(PlayerClassType playerClassType) => _PlayersDict[playerClassType];


}
