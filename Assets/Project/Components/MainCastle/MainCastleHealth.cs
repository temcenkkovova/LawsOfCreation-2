using UnityEngine;

public class MainCastleHealth : Health
{
  protected override void Die()
  {
    //base.Die();
    GameStateController.Instance.SetState(GameState.GameOver);
  }
}