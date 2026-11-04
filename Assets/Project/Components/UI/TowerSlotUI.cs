using TMPro;
using UnityEngine;

public class TowerSlotUI : MonoBehaviour
{
  public TMP_Text titleField;
  public TMP_Text costField;
  public TowerSlot towerSlot;
  void Awake()
  {
    towerSlot.OnTowerSlot += ShowSlotPanel;
  }

  public void ShowSlotPanel(TowerConfig config)
  {
    titleField.text = config.name;
    costField.text = config.cost.ToString();
  }

  void OnDisable()
  {
    towerSlot.OnTowerSlot -= ShowSlotPanel;
  }
}