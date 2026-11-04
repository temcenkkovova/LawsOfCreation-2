using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
  public MainCastleHealth castleHealth;

  void Start()
  {
    if (castleHealth == null) return;
    castleHealth.OnDeath += SetGameOver;
  }


  void OnDestroy()
  {
    if (castleHealth)
      castleHealth.OnDeath -= SetGameOver;
  }
  private void SetGameOver()
  {
    GameStateController.Instance.SetState(GameState.GameOver);
  }

  public void LoadMenuScene()
  {
    GameStateController.Instance.SetState(GameState.Menu);
    SceneManager.LoadScene("MenuScene");
  }
  public void RestartGame()
  {
    GameStateController.Instance.SetState(GameState.Gameplay);
    SceneManager.LoadScene("GameScene");
  }

  public void LoadGameScene()
  {
    SceneManager.LoadScene("GameScene");
    GameStateController.Instance.SetState(GameState.Gameplay);
    GameStateController.Instance.SetPause(false);

  }
}