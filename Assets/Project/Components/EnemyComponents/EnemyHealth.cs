using System;
using UnityEngine;

public class EnemyHealth : Health
{
  //public int Shield;
  [SerializeField] private Transform healthBarPoint; // пустой объект над головой
  [SerializeField] private HealthBar healthBarPrefab;
  private HealthBar healthBar;
  public event Action<Enemy> OnEnemyDeath;
  void Start()
  {
    healthBar = Instantiate(healthBarPrefab, healthBarPoint.position, Quaternion.identity);
    healthBar.transform.SetParent(healthBarPoint);
    healthBar.transform.localPosition = Vector3.zero;
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