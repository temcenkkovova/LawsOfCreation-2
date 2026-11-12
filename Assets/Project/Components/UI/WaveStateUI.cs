using TMPro;
using UnityEngine;
using UnityEngine.UI;


/* Это тестовая компонента , в конца надо удалить */
public class WaveStateUI : MonoBehaviour
{
  // public TMP_Text textField;
  public GameObject rulesPanel;
  public WaveController waveController;
  public TMP_Text buildedTowersField;
  public TMP_Text possibleTowersBuildField;
  public TowerBuildController towerBuildController;
  public Button startWaveBtn;


  void Start()
  {
    ShowGameState(waveController.CurrentWaveState);

    waveController.OnWaveStateChanged += ShowGameState;
    waveController.OnWavePreparing += OpenRules;

    waveController.OnWaveStarted += ShowPossibleTowerAmount;
    ShowPossibleTowerAmount(0);
    towerBuildController.OnTowerBuilded += ShowBuildedTowerAmount;

  }

  void OnDisable()
  {
    waveController.OnWaveStateChanged -= ShowGameState;
    waveController.OnWavePreparing -= OpenRules;
    waveController.OnWaveStarted -= ShowPossibleTowerAmount;
    towerBuildController.OnTowerBuilded -= ShowBuildedTowerAmount;
  }
  public void OpenRules()
  {

  }
  public void ShowGameState(WaveController.WaveState state)
  {
    //textField.text = state.ToString();

    bool active = state == WaveController.WaveState.Preparing;
    rulesPanel.SetActive(active);
    startWaveBtn.gameObject.SetActive(active);
  }

  public void ShowPossibleTowerAmount(int index)
  {

    possibleTowersBuildField.text = towerBuildController.towersPerWave.ToString();

  }
  public void ShowBuildedTowerAmount(BuildSpot spot)
  {
    buildedTowersField.text = towerBuildController.BuildedTowersAmount.ToString();

  }
}