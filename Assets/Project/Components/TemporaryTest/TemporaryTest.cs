using UnityEngine;

public class TemporaryTest : MonoBehaviour
{

  public void SetGameplayStatus()
  {

    GameStateController.Instance.SetState(GameState.Gameplay);
  }
  // public void SetPauseStatus()
  // {
  //   GameStateController.Instance.SetPause(true);
  // }
}