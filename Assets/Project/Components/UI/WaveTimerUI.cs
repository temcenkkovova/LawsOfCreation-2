using System;
using TMPro;
using UnityEngine;

public class WaveTimerUI : MonoBehaviour
{
  public TMP_Text timerField;
  public WaveController waveController;

  void Start()
  {
    waveController.OnWaveTimeChanged += ShowTime;
  }
  void OnDestroy()
  {
    waveController.OnWaveTimeChanged -= ShowTime;
  }

  public void ShowTime(float time)
  {
    int number = (int)time;
    timerField.text = FormatTime(number);
  }
  public string FormatTime(int value)
  {
    TimeSpan time = TimeSpan.FromSeconds(value);
    string formatted = time.ToString(@"mm\:ss");
    return formatted;
  }

}