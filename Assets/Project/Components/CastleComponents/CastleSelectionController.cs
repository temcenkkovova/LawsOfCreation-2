using System;
using UnityEngine;

public class CastleSelectionController : MonoBehaviour
{



  public static CastleSelectionController Instance;
  public WaveController waveController;
  public TowerMenuUI towerMenuUI;
  [NonSerialized] public Castle current;
  private bool active;
  void Start()
  {
    waveController.OnWaveStateChanged += IsActive;
  }
  void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(gameObject);
      return;
    }
    Instance = this;
  }

  public void Select(Castle castle)
  {

    if (current == castle || !active) return;
    current = castle;

    towerMenuUI.Open(castle);
  }
  public void Clear()
  {

    current = null;

    towerMenuUI.Close();
  }
  public void IsActive(WaveController.WaveState state)
  {
    active = state == WaveController.WaveState.Running;
    if (state != WaveController.WaveState.Running)
    {
      Clear();
    }
  }



}