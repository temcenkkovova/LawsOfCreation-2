using System;
using UnityEngine;

public class EnemyHealth : Health
{
  public event Action<Enemy> OnEnemyDeath;
  void Start()
  {

  }

  public void HealthMultiply(float multiply)
  {
    currentHealth = currentHealth * multiply;
  }
  public void SetShield(int shield)
  {
    Shield = shield;
  }

  protected override void Die()
  {
    base.Die();
    OnEnemyDeath?.Invoke(gameObject.GetComponent<Enemy>());
    Destroy(gameObject);
  }
}