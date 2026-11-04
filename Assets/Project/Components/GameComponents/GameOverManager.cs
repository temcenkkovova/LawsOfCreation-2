using System;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
  public GameFlowController gameFlowController;

  public event Action<GameOverDates> OnGameOverData;
  public EnemyScore enemyScore;

  void Start()
  {
    GameStateController.Instance.OnGameStateChanged += GameOverData;
  }

  public void GameOverData(GameState gameState)
  {

    if (gameState == GameState.GameOver)
    {
      OnGameOverData?.Invoke(new GameOverDates
      {
        waveCount = gameFlowController.currentIndexWave - 1,
        killedCount = enemyScore.EnemyDeathAmount,
        state = gameState
      }
      );
    }
  }
  void OnDisable()
  {
    GameStateController.Instance.OnGameStateChanged -= GameOverData;
  }
}