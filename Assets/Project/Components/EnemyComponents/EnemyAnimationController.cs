using System;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
  public Animator animator;

  private float baseSpeed;
  public bool isSprint = false;
  public void Initialize(float baseMoveSpeed)
  {
    baseSpeed = baseMoveSpeed;
  }

  void Start()
  {

    GameStateController.Instance.OnGameStateChanged += ActiveStatusAnimator;

  }

  void OnDisable()
  {
    GameStateController.Instance.OnGameStateChanged -= ActiveStatusAnimator;
  }

  public void UpdateMoveSpeed(float currentSpeed)
  {


    if (isSprint)
    {
      animator.SetBool("IsRunning", true);
    }
    else
    {
      animator.SetBool("IsRunning", false);
    }

  }

  public void TriggerAttack()
  {
    animator.SetTrigger("Attack");
  }

  private void ActiveStatusAnimator(GameState state)
  {

    animator.enabled = state == GameState.Gameplay;
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.T))
    {


      foreach (var info in animator.GetCurrentAnimatorClipInfo(0))
      {
        Debug.Log($"Играет клип: {info.clip.name}");
      }
    }
  }
}