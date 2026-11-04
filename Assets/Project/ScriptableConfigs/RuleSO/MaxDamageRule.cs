

using UnityEngine;
[CreateAssetMenu(menuName = "Rules/Rule MaxDamageRule")]
public class MaxDamageRule : RuleConfig
{
  public float MaxDamage;
  public Vector3 scalePrefab;

  public override void Apply(Enemy enemy)
  {
    enemy.damage.SetModifier(MaxDamage);
    enemy.transform.localScale += scalePrefab;
  }
}