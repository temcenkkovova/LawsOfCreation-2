

using UnityEngine;
[CreateAssetMenu(menuName = "Rules/Rule MaxDamageRule")]
public class MaxDamageRule : RuleConfig
{
  public float MaxDamage;
  public Vector3 scalePrefab;
  public float IncreaseTowerDamagePercentage;

  public override void Apply(Enemy enemy)
  {
    enemy.damage.SetModifier(MaxDamage);
    //enemy.transform.localScale *= 1.2f;
    TowersRulesManager.Instance.SetTowersDamageIncreasePercentage(IncreaseTowerDamagePercentage);
  }
}