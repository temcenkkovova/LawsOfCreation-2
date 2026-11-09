
using UnityEngine;


public class LevelSceneController : MonoBehaviour
{
  public MainCastleHealth mainCastleHealth;
  public ChooseRuleController chooseRuleController;

  void OnDisable()
  {
    SceneLevelManager.Instance.OnNextScene -= SaveCurrentSceneLevelData;
  }
  void Start()
  {
    SceneLevelManager.Instance.OnNextScene += SaveCurrentSceneLevelData;
  }
  public void SaveCurrentSceneLevelData()
  {
    if (mainCastleHealth == null || chooseRuleController == null) return;
    GameStateController.Instance.SaveDataForNextLevelScene(mainCastleHealth.CurrentHealth, chooseRuleController.currentChooseRules);
  }
}