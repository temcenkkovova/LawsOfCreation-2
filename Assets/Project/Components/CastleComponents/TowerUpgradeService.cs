using System;
using UnityEngine;

public class TowerUpgradeService : MonoBehaviour
{
  public GameEconomy gameEconomy;
  public static TowerUpgradeService Instance;
  public event Action OnUpgrade;


  void Awake()
  {
    Instance = this;
  }


  public void TryUpgradeTower(Castle castle)
  {
    CastleLevelSystem castleLevelSystem = castle.GetComponent<CastleLevelSystem>();
    if (castleLevelSystem == null) return;

    if (!castleLevelSystem.IsNextLevel) return;
    if (gameEconomy.TrySpend(castleLevelSystem.UpdateCost))
    {
      castleLevelSystem.ApplyLevel(castleLevelSystem.currentTowerLevel + 1);
      castle.UnSelected();
      OnUpgrade?.Invoke();
      //TowerMenuUI.Instance.Close();
    }
  }

  public bool CanUpdate(CastleLevelSystem castleLevelSystem)
  {
    bool canUpdate = gameEconomy.HasEnough(castleLevelSystem.UpdateCost) &&
 castleLevelSystem.IsNextLevel;
    return canUpdate;
  }

}