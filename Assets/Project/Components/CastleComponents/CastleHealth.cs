using System;
using UnityEngine;

public class CastleHealth : Health
{

  void Start()
  {

    OnHealthChanged += ShowHealth;
  }
  public void ShowHealth(float health)
  {

  }
  protected override void Die()
  {
    //base.Die();

    GameStateController.Instance.SetState(GameState.GameOver);
  }
}
