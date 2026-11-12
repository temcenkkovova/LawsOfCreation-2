
using UnityEngine;


public class LevelSceneController : MonoBehaviour
{
  public MainCastleHealth mainCastleHealth;
  public ChooseRuleController chooseRuleController;
  public GameManagerController gameManagerController;

  void OnDisable()
  {
    SceneLevelManager.Instance.OnNextScene -= SaveCurrentSceneLevelData;
    gameManagerController.OnRestart -= HandleRestartGame;
  }
  void Start()
  {
    SceneLevelManager.Instance.OnNextScene += SaveCurrentSceneLevelData;
    gameManagerController.OnRestart += HandleRestartGame;
  }
  public void SaveCurrentSceneLevelData()
  {
    if (mainCastleHealth == null || chooseRuleController == null) return;
    GameStateController.Instance.SaveDataForNextLevelScene(mainCastleHealth.CurrentHealth, chooseRuleController.currentChooseRules);
  }

  public void HandleRestartGame()
  {
    GameStateController.Instance.ResetData();
  }
}