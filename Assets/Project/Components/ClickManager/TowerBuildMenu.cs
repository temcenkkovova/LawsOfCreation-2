using System.Collections.Generic;
using UnityEngine;

public class TowerBuildMenu : MonoBehaviour
{
  public List<TowerConfig> towers = new();
  public TowerSlot prefabSlot;
  public Transform gridParent;
  public TowerBuildController buildController;

  void Start()
  {

    if (towers.Count <= 0 || !prefabSlot) return;
    for (int i = 0; i < towers.Count; i++)
    {
      TowerSlot slot = Instantiate(prefabSlot, gridParent);
      slot.Init(towers[i], buildController);

    }
  }
}