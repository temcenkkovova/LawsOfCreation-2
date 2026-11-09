
using UnityEngine;


public class LevelSceneController : MonoBehaviour
{
  public MainCastleHealth mainCastleHealth;
  public ChooseRuleController chooseRuleController;

  void OnDisable()
  {
    SceneLevelManager.Instance.OnNextScene -= SaveCurrentSceneLevelData;
    SceneLevelManager.Instance.OnRestartGame -= HandleRestartGame;
  }
  void Start()
  {
    SceneLevelManager.Instance.OnNextScene += SaveCurrentSceneLevelData;
    SceneLevelManager.Instance.OnRestartGame += HandleRestartGame;
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