
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
  public GameObject GameOverPanel;

  public TMP_Text waveField;
  public TMP_Text killedField;
  public GameOverManager gameOverManager;


  void Start()
  {
    gameOverManager.OnGameOverData += OpenPanel;
  }


  void OnDisable()
  {
    gameOverManager.OnGameOverData -= OpenPanel;
  }
  private void OpenPanel(GameOverDates dates)
  {
    bool active = dates.state == GameState.GameOver;
    GameOverPanel.SetActive(active);
    if (!active) return;
    waveField.text = dates.waveCount.ToString();
    killedField.text = dates.killedCount.ToString();
  }
}