using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Gameplay, Menu, GameOver }
public class GameStateController : MonoBehaviour
{
  public static GameStateController Instance { get; private set; } // делаю эту компоненту видимой для любой компоненты ( только get )
  public GameState CurrentState;

  public event Action<GameState> OnGameStateChanged;
  public event Action<bool> OnPauseChanged;

  public bool IsPause;

  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
  }

  /* I`ll use it when have Menu System

  // void OnEnable()
  // {
  //   SceneManager.sceneLoaded += OnSceneLoaded;
  // }
  // void OnDisable()
  // {
  //   SceneManager.sceneLoaded -= OnSceneLoaded;
  // }

  // public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
  // {
  //   SetState(GameState.Gameplay);
  // }

*/
  public void SetPause(bool pause)
  {
    if (IsPause == pause) return;
    IsPause = pause;
    Time.timeScale = IsPause ? 0f : 1f;
    OnPauseChanged?.Invoke(IsPause);
  }

  public void SetState(GameState state)
  {
    if (CurrentState == state) return;

    CurrentState = state;
    OnGameStateChanged?.Invoke(CurrentState);

  }
}
