using System.Linq;
using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
  public TMP_Text textField;
  public GameFlowController gameFlowController;

  void Start()
  {
    ShowWave();
    gameFlowController.OnWaveIndexChanged += ShowWave;
  }

  void OnDisable()
  {
    gameFlowController.OnWaveIndexChanged -= ShowWave;
  }
  public void ShowWave()
  {
    textField.text = (gameFlowController.currentIndexWave + 1).ToString() + " / " + gameFlowController.waveConfigs.Length;
  }
}