using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  [NonSerialized] public EnemyMovement enemyMovement;
  public event Action OnTarget;
  void Awake()
  {
    enemyMovement = GetComponent<EnemyMovement>();
    GameStateController.Instance.OnGameStateChanged += OnGameStateChanged;
  }

  void OnDisable()
  {
    GameStateController.Instance.OnGameStateChanged -= OnGameStateChanged;
  }

  private void OnGameStateChanged(GameState state)
  {
    enemyMovement.enabled = state == GameState.Gameplay;
  }

  public void OnTriggerEnter(Collider other)
  {
    if (other.tag == "MainTarget")
    {
      OnTarget?.Invoke();
      enemyMovement.enabled = false;
      enemyMovement.SetSpeedMultiplier(0f);
    }
  }




}