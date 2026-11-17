using System;

public class CastleData
{

  public float Damage { get; private set; }
  public float AttackInterval { get; private set; }

  public int CurrentLevel { get; private set; }
  public event Action<int> OnLevelChanged;
  public event Action OnStatsChanged;




  public CastleData(TowerConfig towerConfig)
  {
    Damage = towerConfig.levels[CurrentLevel].attackConfig.attackDamage;
    AttackInterval = towerConfig.levels[CurrentLevel].attackConfig.attackInterval;

  }

  public void LevelUp(int level, AttackConfig attackConfig)
  {
    CurrentLevel = level;
    Damage = attackConfig.attackDamage;
    AttackInterval = attackConfig.attackInterval;
    ApplyTowerRules();
    OnLevelChanged?.Invoke(CurrentLevel);
  }


  public void ApplyTowerRules()
  {
    Damage *= 1f + (TowersRulesManager.Instance.DamageIncreasePercentage / 100);
    AttackInterval *= 1f + (TowersRulesManager.Instance.AttackIntervalIncreasePercentage / 100);
    OnStatsChanged?.Invoke();
  }

}