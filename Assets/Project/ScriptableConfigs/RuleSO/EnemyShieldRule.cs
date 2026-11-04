

using UnityEngine;
[CreateAssetMenu(menuName = "Rules/Rule Shield")]
public class EnemyShieldRule : RuleConfig
{
  public int ShieldHealth;
  public Vector3 scalePrefab;

  public override void Apply(Enemy enemy)
  {
    enemy.health.SetShield(ShieldHealth);
    enemy.transform.localScale += scalePrefab;
  }
}