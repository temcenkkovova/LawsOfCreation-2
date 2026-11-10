using System;
using UnityEngine;

public class GameFlowController : MonoBehaviour
{
  private WaveController waveController;
  public WaveConfig[] waveConfigs;
  [NonSerialized] public int currentIndexWave;
  private EnemyWaveController enemyWaveController;
  public PathManager pathManager;
  public MainCastle castle;
  public TowerBuildController towerBuildController;
  public bool IsLastWave { get; private set; }
  public event Action OnLastWave;


  public event Action OnWaveIndexChanged;
  void Awake()
  {
    waveController = GetComponent<WaveController>();
    enemyWaveController = GetComponent<EnemyWaveController>();

  }
  void Start()
  {
    GameStateController.Instance.OnGameStateChanged += OnGameStateChanged;
    enemyWaveController.OnAllEnemiesDefeated += FinishCurrentWave;

  }

  void OnEnable()
  {
    IsLastWave = false;
  }
  void OnDisable()
  {
    GameStateController.Instance.OnGameStateChanged -= OnGameStateChanged;
    enemyWaveController.OnAllEnemiesDefeated -= FinishCurrentWave;
  }


  private void OnGameStateChanged(GameState state)
  {
    if (waveController == null) return;
    Debug.Log(state);
    waveController.enabled = state == GameState.Gameplay;
    CastleAttackController castleAttackController = castle.GetComponent<CastleAttackController>();
    enemyWaveController.enabled = state == GameState.Gameplay;
    castleAttackController.enabled = state == GameState.Gameplay;
  }

  public void FinishCurrentWave()
  {
    WaveConfig config = waveConfigs[currentIndexWave];
    waveController.FinishWave(config.Reward);

    if (IsLastWave)
    {
      OnLastWave?.Invoke();
    }

  }
  public void StartCurrentWave()
  {

    WaveConfig config = waveConfigs[currentIndexWave];

    enemyWaveController.SetEnemyWave(config.enemies, pathManager.GetPath(config.pathType).pointers, config.spawnInterval);
    towerBuildController.InitAmountMaxTowers(config.maxTowerAmount);
    OnWaveIndexChanged?.Invoke();
    waveController.StartWave(config.indexWave, config.duration);
    if (currentIndexWave == waveConfigs.Length - 1) /*It`s a temporary solution */
    {
      IsLastWave = true;
      Debug.Log("You won all  waves");

    }
    else
    {
      currentIndexWave++;
    }

  }
}