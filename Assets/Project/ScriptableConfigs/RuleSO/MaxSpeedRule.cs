

using UnityEngine;
[CreateAssetMenu(menuName = "Rules/Rule MaxSpeedRule")]
public class MaxSpeedRule : RuleConfig
{
  public float MaxSpeed;
  public float coinRewardMultiplyPercentage;


  public override void Apply(Enemy enemy)
  {
    enemy.enemyMovement.SetSpeedMultiplier(MaxSpeed); // тут изменить 
    enemy.MultiplyReward(coinRewardMultiplyPercentage);

  }
}