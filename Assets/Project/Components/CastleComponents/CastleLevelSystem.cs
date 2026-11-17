using System;
using System.Collections.Generic;
using UnityEngine;
public struct NextLevelData
{
  public float damage;
  public float radius;
}

public class CastleLevelSystem : MonoBehaviour
{
  public int currentTowerLevel => castleData.CurrentLevel;
  public bool IsNextLevel => castleData.CurrentLevel + 1 < castle.config.levels.Length ? true : false;
  public float UpdateCost => levelData.updateCost;
  public TowerLevel levelData { get; private set; }
  private Castle castle;
  public int MaxLevels => castle.config.levels.Length;
  public event Action<int> OnLevelChanged; // Need to replace this event to CastleData  . Before need connect UI with this event in CastleData
  public event Action<TowerLevel, int> OnNewTowerData;
  public CastleData castleData { get; private set; }

  void Awake()
  {
    castle = GetComponent<Castle>();
  }
  void Start()
  {

    ApplyLevel(0);

  }

  public void Init(CastleData castleData)
  {
    this.castleData = castleData;
  }

  public void ApplyLevel(int newLevel)
  {

    TowerConfig config = castle.config;
    // currentTowerLevel = indexLevel;

    GameObject visualPrefab = config.levels[newLevel].visualPrefab;
    levelData = new TowerLevel(config.levels[newLevel]);
    //castleData.LevelUp(newLevel, levelData.attackConfig);
    OnNewTowerData?.Invoke(levelData, newLevel);
    if (castle.VisualRoot.childCount > 0)
    {
      var children = castle.VisualRoot.GetChild(0).gameObject;
      Destroy(children);
      castle.newVisual = Instantiate(visualPrefab, castle.VisualRoot);
    }
    else
    {
      castle.newVisual = Instantiate(visualPrefab, castle.VisualRoot);
    }
    OnLevelChanged?.Invoke(newLevel); // 
    Rotate rotate = castle.newVisual.GetComponentInChildren<Rotate>();
    if (rotate != null)
    {
      GetComponent<CastleRotate>().SetNewTransform(rotate.transform);
    }
    else
    {
      Debug.Log("Rotate missing on prefab: " + visualPrefab.name);
    }
  }

  void OnDisable()
  {

  }
  public NextLevelData GetNextLevelData()
  {
    TowerLevel nextLevel = castle.config.levels[currentTowerLevel + 1];
    NextLevelData data = new NextLevelData
    {
      damage = nextLevel.attackConfig.attackDamage,
      radius = nextLevel.attackConfig.radiusAttack
    };
    return data;
  }
}