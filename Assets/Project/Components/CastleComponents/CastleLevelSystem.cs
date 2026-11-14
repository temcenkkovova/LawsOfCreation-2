using System;

using UnityEngine;

public class CastleLevelSystem : MonoBehaviour
{
  [NonSerialized] public int currentTowerLevel;
  public bool IsNextLevel => currentTowerLevel + 1 < castle.config.levels.Length ? true : false;
  public int UpdateCost => castle.config.levels[currentTowerLevel].updateCost;
  public TowerLevel levelData { get; private set; }
  private Castle castle;
  public int MaxLevels => castle.config.levels.Length;
  public event Action<int> OnLevelChanged;
  public event Action<TowerLevel> OnNewTowerData;

  void Awake()
  {
    castle = GetComponent<Castle>();
  }
  void Start()
  {

    ApplyLevel(0);
  }

  public void ApplyLevel(int indexLevel)
  {
    TowerConfig config = castle.config;
    currentTowerLevel = indexLevel;
    GameObject visualPrefab = config.levels[currentTowerLevel].visualPrefab;
    levelData = config.levels[currentTowerLevel];
    OnNewTowerData?.Invoke(levelData);
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
    OnLevelChanged?.Invoke(currentTowerLevel);
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
}