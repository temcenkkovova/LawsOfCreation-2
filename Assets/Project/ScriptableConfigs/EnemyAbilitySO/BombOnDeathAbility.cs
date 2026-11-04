
using UnityEngine;

public class BombOnDeathAbility : EnemyAbility
{
  public GameObject bombPrefab;

  private void Start()
  {
    enemy.health.OnDeath += SpawnBomb;
  }

  private void OnDisable()
  {
    enemy.health.OnDeath -= SpawnBomb;
  }

  private void SpawnBomb()
  {
    Instantiate(bombPrefab, enemy.transform.position, Quaternion.identity);
  }

}