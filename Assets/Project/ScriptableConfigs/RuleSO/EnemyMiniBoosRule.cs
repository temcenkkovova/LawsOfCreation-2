

using UnityEngine;
[CreateAssetMenu(menuName = "Rules/Rule/Boos/Mini")]
public class EnemyMiniBoosRule : RuleConfig
{
  public int ShieldHealth;
  public float Speed;
  public Vector3 scalePrefab;

  public override void Apply(Enemy enemy)
  {
    enemy.health.SetShield(ShieldHealth);
    enemy.enemyMovement.SetSpeedMultiplier(Speed);
    enemy.transform.localScale += scalePrefab;
  }
}