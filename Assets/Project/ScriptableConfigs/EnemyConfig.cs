using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Enemy Config")]
public class EnemyConfig : ScriptableObject
{

  public Enemy prefab;
  public int maxHealth;
  public int coinReward;
  public float speed;
  public AttackConfig attackConfig; // потом переделать на attackConfig и damage перенести туда 
  public AudioConfig audioConfig;
  // public Transform target;

}