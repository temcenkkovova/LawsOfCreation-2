using System;
using UnityEngine;

public class FindEnemySystem : MonoBehaviour
{

  private float radiusSqr;
  private float checkTimer;
  public float checkInterval = 0.2f;
  private Enemy currentTarget;
  public Enemy CurrentTarget => currentTarget;
  public event Action<Enemy> OnEnemy;
  private IEnemyProvider enemyProvider;
  public MonoBehaviour enemyProviderResource;



  void Update()
  {

    checkTimer += Time.deltaTime;
    if (checkTimer >= checkInterval)
    {
      checkTimer = 0;
      if (currentTarget == null || (currentTarget.transform.position - transform.position).sqrMagnitude > radiusSqr)
      {
        FindEnemy();
      }

    }
  }
  public void FindEnemy()
  {

    var enemies = enemyProvider.GetEnemies();
    Enemy target = null;
    float closestDistance = float.MaxValue;

    foreach (Enemy enemy in enemies)
    {
      float dist = (enemy.transform.position - transform.position).sqrMagnitude;
      if (dist < radiusSqr && dist < closestDistance)
      {
        closestDistance = dist;
        target = enemy;
      }
    }
    if (target != currentTarget)
    {
      currentTarget = target;
      OnEnemy?.Invoke(currentTarget);
    }

  }

  public void SetConfigData(AttackConfig config, IEnemyProvider enemyProvider)
  {
    radiusSqr = config.radiusAttack * config.radiusAttack;

    this.enemyProvider = enemyProvider;
  }
}