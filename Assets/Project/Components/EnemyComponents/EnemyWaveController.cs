using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveController : MonoBehaviour, IEnemyProvider
{

  public ChooseRuleController chooseRuleController;
  public List<EnemyConfig> Enemies = new();
  private List<Enemy> spawnedEnemies = new();
  // It is better to have two lists of enemies: one for spawned enemies and another for  alive enemies. I can leave it like that for now.
  private List<Vector3> enemiesPaths = new();
  public MainCastle target;
  private float spawnInterval = 4f;
  private Coroutine spawnCoroutine;
  public event Action OnAllEnemiesDefeated;
  private bool spawningFinished;
  public CoinRewards coinRewards;
  public EnemyScore enemyScore;
  public List<Enemy> GetEnemies() => spawnedEnemies;


  void Awake()
  {
    //Instance = this;
  }
  public void SetEnemyWave(List<EnemyConfig> enemies, List<Vector3> path)
  {
    Enemies = enemies;
    enemiesPaths = new List<Vector3>(path);
  }

  public void SpawnEnemyWave()
  {
    spawnCoroutine = StartCoroutine(SpawnEnemyCoroutine());
  }
  public void StopSpawnEnemy()
  {
    if (spawnCoroutine == null) return;

    StopCoroutine(spawnCoroutine);
  }

  void OnDisable()
  {
    StopSpawnEnemy();
    spawnedEnemies.Clear();
    enemiesPaths.Clear();
  }
  private IEnumerator SpawnEnemyCoroutine()
  {
    yield return new WaitForSeconds(1f);
    if (Enemies == null) yield break;

    spawningFinished = false;
    foreach (var item in Enemies)
    {
      if (item == null || item.prefab == null)
      {
        Debug.LogWarning("EnemyConfig or prefab missing");
        continue;
      }
      EnemyConfig config = item;
      Enemy enemy = Instantiate(config.prefab);

      spawnedEnemies.Add(enemy);
      if (target == null) yield break;
      if (enemiesPaths[0] != null)
      {

        enemy.InitPosition(enemiesPaths[0]);
        enemy.SetData(item, new List<RuleConfig>(chooseRuleController.currentChooseRules), target, enemiesPaths);
      }
      enemy.health.OnEnemyDeath += HandleEnemyDeath;
      if (spawnedEnemies.Count == Enemies.Count) spawningFinished = true;

      yield return new WaitForSeconds(spawnInterval);
    }
  }
  public void HandleEnemyDeath(Enemy enemy)
  {
    if (!enemy || !spawnedEnemies.Contains(enemy)) return;
    enemy.health.OnEnemyDeath -= HandleEnemyDeath;
    coinRewards.ChangeBalance(+enemy.enemyConfig.coinReward);
    spawnedEnemies.Remove(enemy);
    enemyScore.IncreaseEnemyDeathAmount();
    if (spawnedEnemies.Count == 0)
    {
      OnAllEnemiesDefeated?.Invoke();
    }
  }
}