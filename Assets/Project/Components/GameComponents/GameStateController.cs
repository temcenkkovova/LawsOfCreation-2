using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Gameplay, Menu, GameOver }
public class GameStateController : MonoBehaviour
{
  public static GameStateController Instance { get; private set; }
  public GameState CurrentState;

  public event Action<GameState> OnGameStateChanged;
  public event Action<bool> OnPauseChanged;
  public float MainCastleHealth { get; private set; }
  [NonSerialized] public List<RuleConfig> choseRuleConfig;
  public bool IsStartData { get; private set; } = true;

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

  public void SaveDataForNextLevelScene(float health, List<RuleConfig> rules)
  {
    choseRuleConfig = null;
    MainCastleHealth = health;

    choseRuleConfig = new(rules);
    IsStartData = false;
  }
  public void ResetData()
  {
    IsStartData = true;
    choseRuleConfig = null;
    MainCastleHealth = 0;
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
