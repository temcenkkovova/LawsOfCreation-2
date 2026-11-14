using System;
using UnityEngine;



public class Castle : MonoBehaviour, ISellable, ITowerSelectable
{
  public TowerConfig config;

  public CastleHealth health;
  public int BuyCost => config.cost;

  private Attack attack;
  private CastleAttackController castleAttackController;
  private FindEnemySystem findEnemySystem;
  public event Action OnSelected;
  public Transform VisualRoot;
  [NonSerialized] public GameObject newVisual;
  private AttackAudio attackAudio;
  private CastleLevelSystem castleLevelSystem;
  public event Action OnUnSelected;
  public event Action<Castle> OnSell;


  [NonSerialized] public BuildSpot buildSpot;
  private EnemyWaveController enemyController;


  void Awake()
  {
    findEnemySystem = GetComponent<FindEnemySystem>();
    castleAttackController = GetComponent<CastleAttackController>();
    attack = GetComponent<Attack>();
    attackAudio = GetComponent<AttackAudio>();
    castleLevelSystem = GetComponent<CastleLevelSystem>();
    castleLevelSystem.OnNewTowerData += NewLevelData;
  }

  public void SetConfig(TowerConfig castleConfig, EnemyWaveController enemyWaveController)
  {
    config = castleConfig;
    enemyController = enemyWaveController;

  }

  public void NewLevelData(TowerLevel towerLevel)
  {
    if (health && attack && castleAttackController && findEnemySystem && attackAudio)
    {
      health.Init(towerLevel.Health);
      attack.InitConfigs(towerLevel.attackConfig, config.audioConfig);
      castleAttackController.SetConfig(towerLevel.attackConfig);
      IEnemyProvider provider = enemyController as IEnemyProvider;

      findEnemySystem.SetConfigData(towerLevel.attackConfig, provider);
      attackAudio.Init(towerLevel.audioConfig);

    }
  }

  public float GetTowerAttackDamage()
  {
    return castleAttackController.attackConfig.attackDamage;
  }
  public float GetTowerAttackRange()
  {
    return castleAttackController.attackConfig.radiusAttack;
  }
  public string GetTowerName()
  {
    return castleLevelSystem.levelData.name;
  }
  public int GetSellValue()
  {
    return BuyCost;
  }
  public void SellItem()
  {
    //buildSpot.ownSpotCastle = null;
    OnSell?.Invoke(this);
    GameEconomy.Instance.Sell(this);
    buildSpot.ActiveSlot();
    UnSelected();
    Destroy(gameObject);

  }
  public void SetTowerSpot(BuildSpot spot)
  {
    buildSpot = spot;
  }

  public void Selected()
  {

    OnSelected?.Invoke();
  }
  public void UnSelected()
  {
    OnUnSelected?.Invoke();
  }

  public void OnDisable()
  {
    castleLevelSystem.OnNewTowerData -= NewLevelData;
  }

}