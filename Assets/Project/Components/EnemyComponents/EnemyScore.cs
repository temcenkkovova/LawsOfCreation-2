using UnityEngine;

public class EnemyScore : MonoBehaviour
{
  private int enemyDeath = 0;

  public int EnemyDeathAmount => enemyDeath;


  public void IncreaseEnemyDeathAmount()
  {
    enemyDeath++;
  }

}