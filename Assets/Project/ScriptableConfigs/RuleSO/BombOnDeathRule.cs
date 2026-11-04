using UnityEngine;
[CreateAssetMenu(menuName = "Rules/Rule BombOnDeath")]
public class BombOnDeathRule : RuleConfig
{
  public GameObject bombAbilityPrefab;

  public override void Apply(Enemy enemy)
  {
    var ability = enemy.gameObject.AddComponent<BombOnDeathAbility>();
    ability.bombPrefab = bombAbilityPrefab;
    ability.Init(enemy);
  }

}