using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
GameManager handles the general game states, it does not know anything about the current map or objective,
only changing between the general game states as needed
 */
public class GameManager : Singleton<GameManager>
{
    public static event Action<GameState> OnBeforeStateChanged;
    //public static event Action<GameState> OnAfterStateChanged;

    public GameState? State { get; private set; } = null;

    [SerializeField] private InputReader _input;
    [SerializeField] private GameObject pauseMenu;

    private void OnEnable()
    {
        _input.PauseEvent += HandlePause;
        _input.ResumeEvent += HandleResume;
    }

    private void OnDisable()
    {
        _input.PauseEvent -= HandlePause;
        _input.ResumeEvent -= HandleResume;
    }

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
                HandleWinning();
                break;
            case GameState.Lose:
                HandleLosing();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        //OnAfterStateChanged?.Invoke(newState);
    }

    private void HandleStarting()
    {
        UnitManager.Instance.SpawnPlayer();
        Debug.Log("GameManager: Handled start successfully");
    }

    private void HandlePause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Debug.Log("GameManager: Handled pause successfully");
    }

    private void HandleResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("GameManager: Handled resume successfully");
    }

    private void HandleWinning()
    {
        SceneTransitioner.Instance.LoadSceneMenu();
        Debug.Log("GameManager: Handled winning successfully");
    }

    private void HandleLosing()
    {
        SceneTransitioner.Instance.LoadSceneMenu();
        Debug.Log("GameManager: Handled losing successfully");
    }
}





[Serializable]
public enum GameState
{
    Starting = 0,
    Win = 1,
    Lose = 2,
}