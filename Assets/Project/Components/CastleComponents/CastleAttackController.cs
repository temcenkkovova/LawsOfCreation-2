using System;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CastleAttackController : MonoBehaviour
{
  private AttackConfig attackConfig;
  private CastleShoot castleShoot;
  private Enemy currentTarget;
  private float shootTimer;
  private FindEnemySystem findEnemySystem;
  void Awake()
  {
    castleShoot = GetComponent<CastleShoot>();
    findEnemySystem = GetComponent<FindEnemySystem>();
    if (findEnemySystem != null)
      findEnemySystem.OnEnemy += SetEnemyTarget;


  }

  void Update()
  {
    if (currentTarget == null || attackConfig == null) return;

    shootTimer += Time.deltaTime;

    if (shootTimer >= attackConfig.attackInterval)
    {
      shootTimer = 0;
      castleShoot.Shoot(currentTarget.transform);
    }
  }
  public void SetEnemyTarget(Enemy enemy)
  {
    if (currentTarget != null)
    {
      Health oldHealth = currentTarget.GetComponent<Health>();
      if (oldHealth != null)
      {
        oldHealth.OnDeath -= ClearTarget;
      }
    }
    currentTarget = enemy;
    if (currentTarget != null)
    {
      Health health = currentTarget.GetComponent<Health>();
      if (health != null)
      {
        health.OnDeath += ClearTarget;
      }
    }

  }

  void OnDisable()
  {
    if (findEnemySystem != null)
      findEnemySystem.OnEnemy -= SetEnemyTarget;

    if (currentTarget != null)
    {
      var health = currentTarget.GetComponent<Health>();
      if (health != null)
        health.OnDeath -= ClearTarget;
    }
  }
  public void SetConfig(AttackConfig config)
  {
    attackConfig = config;
  }

  public void ClearTarget()
  {
    if (currentTarget == null) return;
    currentTarget = null;
    shootTimer = 0f;
  }
}