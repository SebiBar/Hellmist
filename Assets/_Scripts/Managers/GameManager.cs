using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static event Action<GameState> OnBeforeStateChanged;
    //public static event Action<GameState> OnAfterStateChanged;

    public GameState? State { get; private set; } = null;

    [SerializeField] private InputReader _input;
    [SerializeField] private GameObject pauseMenu;

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

        //OnAfterStateChanged?.Invoke(newState);
    }

    private void HandleStarting()
    {
        _input.PauseEvent += HandlePause;
        _input.ResumeEvent += HandleResume;

        Debug.Log("works");
        UnitManager.Instance.SpawnPlayer();

    }

    private void HandlePause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Debug.Log("works");
    }

    private void HandleResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}





[Serializable]
public enum GameState
{
    Starting = 0,
    Win = 1,
    Lose = 2,
}