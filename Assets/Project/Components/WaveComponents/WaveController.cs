using System;
using UnityEngine;

public class WaveController : MonoBehaviour
{
  public enum WaveState { Preparing, Running, Finished };


  [NonSerialized] public float TimeRemaining;
  [NonSerialized] public WaveState CurrentWaveState;
  public CoinRewards coinRewards;

  public event Action<int> OnWaveStarted;
  public event Action<WaveState> OnWaveStateChanged;
  public event Action<float> OnWaveTimeChanged;
  public event Action OnWavePreparing;
  public event Action OnWaveFinished;

  public void StartWave(int waveIndex, float duration)
  {
    TimeRemaining = duration;
    CurrentWaveState = WaveState.Running;
    OnWaveStarted?.Invoke(waveIndex);
    OnWaveStateChanged?.Invoke(CurrentWaveState);
  }

  public void FinishWave(int waveReward)
  {
    CurrentWaveState = WaveState.Finished;
    OnWaveFinished?.Invoke();
    OnWaveStateChanged?.Invoke(CurrentWaveState);
    coinRewards.ChangeBalance(+waveReward);
  }

  public void WavePreparing()
  {
    CurrentWaveState = WaveState.Preparing;
    OnWavePreparing?.Invoke();
    OnWaveStateChanged?.Invoke(CurrentWaveState);
  }
  void Update()
  {
    if (CurrentWaveState != WaveState.Running) return;
    TimeRemaining -= Time.deltaTime;
    OnWaveTimeChanged?.Invoke(TimeRemaining);
    if (TimeRemaining <= 0f)
    {

      FinishWave(0);
    }

  }
}