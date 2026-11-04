using System;
using UnityEngine;

public class Attack : MonoBehaviour, IDamageSource
{
  [NonSerialized] public AttackConfig attackConfig;
  [NonSerialized] public AudioConfig audioConfig;
  public float damageModification = 0f;
  public void InitConfigs(AttackConfig attackConfig, AudioConfig audioConfig)
  {
    this.attackConfig = attackConfig;
    this.audioConfig = audioConfig;
  }

  public void SetModifier(float damageModify)
  {
    damageModification = damageModify;
  }
  public float GetDamage()
  {
    if (!attackConfig) return 0f;
    float totalDamage = damageModification > 0 ? attackConfig.attackDamage * damageModification : attackConfig.attackDamage;
    return totalDamage;

  }
  public void ReleaseAttack(IDamageable damageable)
  {
    if (damageable == null) return;
    damageable.TakeDamage(new DamageInfo
    {
      Damage = GetDamage(),
      audio = audioConfig,

    });
  }
}