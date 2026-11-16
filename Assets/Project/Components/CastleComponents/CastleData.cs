using System;

public class CastleData
{

  public float Damage { get; private set; }
  public float AttackInterval { get; private set; }

  public int CurrentLevel { get; private set; }
  public event Action<int> OnLevelChanged;




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
    OnLevelChanged?.Invoke(CurrentLevel);
  }

}