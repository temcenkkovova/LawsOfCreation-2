using UnityEngine;
[System.Serializable]
public class TowerLevel
{
  public string name;
  public float Health;
  public AttackConfig attackConfig;
  public float updateCost;
  public float temporaryCost;
  public GameObject visualPrefab;
  public AudioConfig audioConfig;



  public void ChangeUpdateCost(float percentage)
  {
    temporaryCost = updateCost * (1f - percentage / 100);
  }

  public TowerLevel(TowerLevel tower)
  {
    name = tower.name;
    attackConfig = tower.attackConfig;
    updateCost = tower.updateCost;
    temporaryCost = tower.updateCost;
    visualPrefab = tower.visualPrefab;
    audioConfig = tower.audioConfig;
  }
}