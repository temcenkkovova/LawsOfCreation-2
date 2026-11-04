using UnityEngine;

public class WaveManager : MonoBehaviour
{
  public WaveController waveController;
  void Start()
  {
    if (!waveController) return;
    waveController.OnWaveFinished += HandleFinishWave;
    waveController.OnWavePreparing += HandlePreparingWave;
  }
  public void HandleFinishWave()
  {

    waveController.WavePreparing();
  }
  public void HandlePreparingWave()
  {

  }
}