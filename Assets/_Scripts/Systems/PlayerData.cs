using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : Singleton<PlayerData>
{
    private PlayerClassType _playerClass;

    public PlayerClassType PlayerClass { get => _playerClass; set => _playerClass = value; }

    public void SelectClassAnkou()
    {
        PlayerClass = PlayerClassType.Ankou;
    }

    public void SelectClassAsura()
    {
        PlayerClass = PlayerClassType.Asura;
    }
}
