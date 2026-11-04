using UnityEngine;


[CreateAssetMenu(menuName = "Projectile")]
public class ProjectileConfig : ScriptableObject
{
  public Projectile prefab;
  // public float damage;
  public float speed;
}