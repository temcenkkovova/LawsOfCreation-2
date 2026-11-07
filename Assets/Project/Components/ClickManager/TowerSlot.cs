using System;
using UnityEngine;

public class TowerSlot : MonoBehaviour
{

  private TowerConfig config;
  private TowerBuildController buildController;
  public event Action<TowerConfig> OnTowerSlot;
  public BuildSpot buildSpot;

  // void OnEnable()
  // {
  //   if (buildSpot == null) return;
  //   buildSpot.OnSlotClicked += HandleClick;
  // }


  public void Init(TowerConfig config, TowerBuildController controller)
  {
    this.config = config;
    buildController = controller;
    //OnTowerSlot?.Invoke(config);
  }

  public void HandleClick()
  {
    // buildController.Init(config);
    // buildController.HandleSlotClick();
  }

  // void OnDisable()
  // {
  //   if (buildSpot == null) return;
  //   buildSpot.OnSlotClicked -= HandleClick;
  // }

}