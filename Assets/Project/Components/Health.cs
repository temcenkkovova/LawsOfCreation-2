using System;
using Unity.Collections;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
  //[SerializeField] private float maxHealth;
  public float currentHealth;

  public float CurrentHealth => currentHealth;

  public event Action<float> OnHealthChanged;
  public event Action<DamageInfo> OnDamaged;
  public event Action OnDeath;
  public float Shield;

  public void Init(float amount)
  {

    currentHealth = amount;
    OnHealthChanged?.Invoke(currentHealth);

  }
  public void TakeDamage(DamageInfo damageInfo)
  {

    float damage = damageInfo.Damage;
    if (Shield > 0)
    {
      float damageToShield = Mathf.Min(Shield, damage);
      Shield -= damageToShield;
      damage -= damageToShield;
    }

    if (damage > 0)
    {
      currentHealth -= damage;
      if (currentHealth <= 0)
      {

        currentHealth = 0f;
        OnHealthChanged?.Invoke(currentHealth);
        OnDamaged?.Invoke(damageInfo);
        Die();
      }
      else
      {
        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth);
        OnDamaged?.Invoke(damageInfo);
      }
    }
  }
  protected virtual void Die()
  {

    OnDeath?.Invoke();
  }
}