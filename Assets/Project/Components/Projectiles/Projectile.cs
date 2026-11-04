using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  private float Speed;
  private bool active = true;
  [NonSerialized] public Attack attack;
  private Rigidbody projectileRigidbody;
  private Transform targetTransform;
  public void Init(ProjectileConfig config, Transform transformTr, Attack attackRef)
  {
    Speed = config.speed;
    targetTransform = transformTr;
    attack = attackRef;
  }

  void Start()
  {
    GameStateController.Instance.OnGameStateChanged += OnGameStateChanged;
    projectileRigidbody = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
    if (!active)
    {
      return;
    }
    if (!targetTransform)
    {
      Destroy(gameObject);
    }
    else
    {
      Vector3 dir = targetTransform.position - transform.position;
      dir.y = 2f + dir.y;
      dir.Normalize();
      projectileRigidbody.velocity = dir * Speed;
    }
  }

  private void OnGameStateChanged(GameState state)
  {

    active = state == GameState.Gameplay;
    if (!active && projectileRigidbody != null)
    {
      projectileRigidbody.velocity = Vector3.zero;
    }
  }
  private void OnDestroy()
  {
    if (GameStateController.Instance != null)
    {
      GameStateController.Instance.OnGameStateChanged -= OnGameStateChanged;
    }
  }
}