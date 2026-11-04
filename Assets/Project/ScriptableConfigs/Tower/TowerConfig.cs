using UnityEngine;

[CreateAssetMenu(menuName = "TD/Tower")]
public class TowerConfig : ScriptableObject
{
  public int cost;
  public Castle prefab;
  public TowerLevel[] levels;
  public AudioConfig audioConfig;
}