using System;
using UnityEngine;

public class TowerBuildController : MonoBehaviour
{
  [NonSerialized] public TowerConfig towerConfig;
  public GameEconomy gameEconomy;
  public event Action OnTowerBuilded;
  private float buildedTowersAmount = 0;
  public float BuildedTowersAmount => buildedTowersAmount;
  public EnemyWaveController enemyWaveController;
  [NonSerialized] public float towersPerWave;
  public SpotManager spotManager;

  void Start()
  {
    GameEconomy.Instance.OnSellTower += ChangeBuildedTowersAmount;
  }

  void OnDisable()
  {
    GameEconomy.Instance.OnSellTower -= ChangeBuildedTowersAmount;
  }
  public void Init(TowerConfig config)
  {
    towerConfig = config;

  }
  public void ChangeBuildedTowersAmount()
  {
    if (buildedTowersAmount > 0)
      buildedTowersAmount--;
    OnTowerBuilded?.Invoke();
  }
  public void InitAmountMaxTowers(float amount)
  {
    towersPerWave = amount;
  }
  public void HandleSlotClick()
  {
    if (!towerConfig || !spotManager.CurrentBuildSpot) return;
    BuildTower(spotManager.CurrentBuildSpot);
  }

  public void BuildTower(BuildSpot buildSpot)
  {

    if (!buildSpot || buildedTowersAmount >= towersPerWave)
    {
      Debug.Log("Don`t have buildSpot or you builded MAX COUNT OF TOWERS");
    }
    else
    {
      if (!gameEconomy.TrySpend(towerConfig.cost)) return;
      Quaternion rotation = Quaternion.Euler(0f, 0f, 0f); //3.44
      Vector3 pos = new Vector3(buildSpot.transform.position.x, 0f, buildSpot.transform.position.z);
      Castle castle = Instantiate(towerConfig.prefab, pos, rotation);
      castle.SetConfig(towerConfig, enemyWaveController);
      castle.SetTowerSpot(spotManager.CurrentBuildSpot);
      spotManager.CurrentBuildSpot.SetSpotCastle(castle);
      castle.OnSelected += CastleSelectionController.Instance.Select;
      buildedTowersAmount++;
      OnTowerBuilded?.Invoke();
    }
  }
  public void ClearSection()
  {
    towerConfig = null;
  }
}