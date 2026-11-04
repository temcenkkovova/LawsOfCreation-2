using System;
using UnityEngine;

public class CastleShoot : MonoBehaviour
{
  [SerializeField] private ProjectileConfig projectileConfig;
  [SerializeField] private Transform projectileStartPoint;
  [NonSerialized] public Attack attack;
  public event Action OnShoot;

  void Start()
  {
    attack = GetComponent<Attack>();
  }
  public void Shoot(Transform target)
  {
    if (projectileConfig == null && target == null) return;

    Vector3 dir = (target.position - transform.position).normalized;
    Projectile projectile = Instantiate(projectileConfig.prefab, projectileStartPoint.position, projectileStartPoint.rotation);
    OnShoot?.Invoke();
    projectile.Init(projectileConfig, target, attack);
  }
}