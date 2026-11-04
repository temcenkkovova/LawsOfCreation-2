using System;
using System.Collections;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
  [NonSerialized] public EnemyController enemyController;
  [NonSerialized] public Attack enemyDamage;
  [NonSerialized] public EnemyAnimationController enemyAnimationController;
  private MainCastle targetAttack;
  private Coroutine attackCoroutine;
  private MainCastleHealth castleHealth;

  void Awake()
  {
    enemyController = GetComponent<EnemyController>();
    enemyDamage = GetComponent<Attack>();
    enemyAnimationController = GetComponent<EnemyAnimationController>();
    enemyController.OnTarget += StartAttackCoroutine;
    GameStateController.Instance.OnGameStateChanged += OnGameStateChanged;
  }

  void OnDestroy()
  {
    enemyController.OnTarget -= StartAttackCoroutine;
    if (castleHealth != null)
      castleHealth.OnDeath -= StopAttackCoroutine;
  }
  public void OnGameStateChanged(GameState state)
  {
    enabled = state == GameState.Gameplay;
  }

  public void Init(MainCastle target)
  {

    targetAttack = target;
    castleHealth = targetAttack.GetComponent<MainCastleHealth>();
    castleHealth.OnDeath += StopAttackCoroutine;
  }
  void OnDisable()
  {
    GameStateController.Instance.OnGameStateChanged -= OnGameStateChanged;

    if (attackCoroutine != null)
    {
      StopCoroutine(attackCoroutine);
      attackCoroutine = null;
    }
  }
  public void StopAttackCoroutine()
  {
    if (attackCoroutine != null)
    {
      StopCoroutine(attackCoroutine);
      attackCoroutine = null;
    }
  }
  public void StartAttackCoroutine()
  {
    if (attackCoroutine != null) return;
    attackCoroutine = StartCoroutine(StartAttack());
  }
  private IEnumerator StartAttack()
  {
    while (true)
    {

      enemyAnimationController.TriggerAttack();
      enemyDamage.ReleaseAttack(targetAttack.GetComponent<IDamageable>());
      yield return new WaitForSeconds(enemyDamage.attackConfig.attackInterval);
    }



  }

}