using System;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
  [NonSerialized] public Animator animator;
  void Awake()
  {
    animator = GetComponent<Animator>();
    GameStateController.Instance.OnGameStateChanged += ActiveStatusAnimator;
  }
  private float baseSpeed;
  public void Initialize(float baseMoveSpeed)
  {
    baseSpeed = baseMoveSpeed;
  }

  void OnDisable()
  {
    GameStateController.Instance.OnGameStateChanged -= ActiveStatusAnimator;
  }

  public void UpdateMoveSpeed(float currentSpeed)
  {

    float normalizedSpeed = currentSpeed / baseSpeed;

    animator.SetFloat("MoveSpeed", normalizedSpeed);
  }

  public void TriggerAttack()
  {
    animator.SetTrigger("Attack");
  }

  private void ActiveStatusAnimator(GameState state)
  {

    animator.enabled = state == GameState.Gameplay;
  }
}