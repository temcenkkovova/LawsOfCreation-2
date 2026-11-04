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

  public event Action OnWaveIndexChanged;
  void Awake()
  {
    waveController = GetComponent<WaveController>();
    enemyWaveController = GetComponent<EnemyWaveController>(); // возможно надо будет сделать его public и передавать через inspector

  }
  void Start()
  {
    GameStateController.Instance.OnGameStateChanged += OnGameStateChanged;
    enemyWaveController.OnAllEnemiesDefeated += FinishCurrentWave;

  }
  void OnDisable()
  {
    GameStateController.Instance.OnGameStateChanged -= OnGameStateChanged;
    enemyWaveController.OnAllEnemiesDefeated -= FinishCurrentWave;
  }

  /*Логику включение и выключение систем лучше вынести в другую компоненту */
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

  }
  public void StartCurrentWave()
  {

    WaveConfig config = waveConfigs[currentIndexWave];

    enemyWaveController.SetEnemyWave(config.enemies, pathManager.GetPath(config.pathType).pointers);
    towerBuildController.InitAmountMaxTowers(config.maxTowerAmount);
    OnWaveIndexChanged?.Invoke();
    waveController.StartWave(config.indexWave, config.duration);
    if (currentIndexWave == waveConfigs.Length - 1) /*It`s a temporary solution */
    {
      Debug.Log("You won all  waves");
      currentIndexWave = 0;
    }
    else
    {
      currentIndexWave++;
    }

  }
}