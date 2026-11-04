

using UnityEngine;
[CreateAssetMenu(menuName = "Rules/Rule MaxSpeedRule")]
public class MaxSpeedRule : RuleConfig
{
  public float MaxSpeed;


  public override void Apply(Enemy enemy)
  {
    enemy.enemyMovement.SetSpeedMultiplier(MaxSpeed); // тут изменить 

  }
}