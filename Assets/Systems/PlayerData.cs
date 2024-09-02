using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : Singleton<PlayerData>
{
    private PlayerClassType _playerClass;

    public PlayerClassType PlayerClass { get => _playerClass; set => _playerClass = value; }

    protected override void Awake()
    {
        base.Awake();
        PlayerData pd = SaveSystem.LoadPlayerData();
        if (pd != null)
        {
            this.PlayerClass = pd.PlayerClass;
        }
        else Debug.Log("Null Player Data"); //Will be null for now as there is no SaveData
    }

    public void SelectClassAnkou()
    {
        PlayerClass = PlayerClassType.Ankou;
    }

    public void SelectClassAsura()
    {
        PlayerClass = PlayerClassType.Asura;
    }
}
