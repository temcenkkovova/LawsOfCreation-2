using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum WaveDifficulties
{
  Easy,
  Normal,
  Hard,
}
public enum PathType
{
  Path1,
  Path2,
  Path3
}
[CreateAssetMenu(menuName = "Wave/Wave")]
public class WaveConfig : ScriptableObject
{
  public int indexWave;
  public float duration;
  public WaveDifficulties waveDifficulties;
  public PathType pathType;
  public List<EnemyConfig> enemies = new();
  public int Reward;
  public int maxTowerAmount;
}