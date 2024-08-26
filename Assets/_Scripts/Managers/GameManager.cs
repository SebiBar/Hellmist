using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    public GameState State { get; private set; }

    private void Start() => ChangeState(GameState.Starting); 

    public void ChangeState(GameState newState)
    {
        if (State == newState) return;
        OnBeforeStateChanged?.Invoke(newState);
         
        State = newState;
        switch (newState)
        {
            case GameState.Starting:
                HandleStarting();
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState);
    }

    private void HandleStarting()
    {
        UnitManager.Instance.SpawnPlayer();

        ChangeState(GameState.Win);
    }
}





[Serializable]
public enum GameState
{
    Starting = 0,
    Win = 1,
    Lose = 2,
}