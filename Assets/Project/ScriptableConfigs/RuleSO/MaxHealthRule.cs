

using UnityEngine;
[CreateAssetMenu(menuName = "Rules/Rule MaxHealthRule")]
public class MaxHealthRule : RuleConfig
{
  public float MaxHealth;
  public Vector3 scalePrefab;

  public override void Apply(Enemy enemy)
  {
    enemy.health.HealthMultiply(MaxHealth);
    enemy.transform.localScale *= 1.2f; // To make enemy visual greater;
  }
}