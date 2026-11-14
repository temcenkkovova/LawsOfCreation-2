using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelMenuItemsUI : MonoBehaviour
{
  public TMP_Text levelFieldText;
  public Castle castle;
  public Button updateButton;
  public TMP_Text costUpdateField;
  public TMP_Text currentDamageField;
  public TMP_Text currentRadiusAttackField;
  public TMP_Text nextLevelDamageField;
  public TMP_Text nextLevelRadiusAttackField;
  private CastleLevelSystem castleLevelSystem;
  private TowerUpgradeService towerUpgradeService;


  void OnEnable()
  {
    GameEconomy.Instance.coinRewards.OnChangeRewardCoin += RefreshUpdateButton;
  }

  void OnDisable()
  {
    GameEconomy.Instance.coinRewards.OnChangeRewardCoin -= RefreshUpdateButton;
    if (castle != null) castleLevelSystem.OnLevelChanged -= OnLevelChanged;
    if (towerUpgradeService != null) towerUpgradeService.OnUpgrade -= ShowTowerData;
  }
  public void Init(Castle castleRef)
  {
    castle = castleRef;
    castleLevelSystem = castle.GetComponent<CastleLevelSystem>();
    towerUpgradeService = castle.GetComponent<TowerUpgradeService>();
    RefreshAll();
  }

  public void ShowTowerData()
  {
    NextLevelData nextLevelData = castleLevelSystem.GetNextLevelData();
    levelFieldText.text = "Level : " + (castleLevelSystem.currentTowerLevel + 1);
    costUpdateField.text = castleLevelSystem.UpdateCost.ToString();
    currentDamageField.text = castleLevelSystem.levelData.attackConfig.attackDamage.ToString();
    currentRadiusAttackField.text = (castleLevelSystem.levelData.attackConfig.radiusAttack * 100).ToString("F1");

    if (castleLevelSystem.IsNextLevel)
    {
      ShowNextLevelDataPanel();
      nextLevelDamageField.text = nextLevelData.damage.ToString();
      nextLevelRadiusAttackField.text = (nextLevelData.radius * 100).ToString("F1");
    }
    else
    {
      HideNextLevelDataPanel();
    }


  }
  public void HideNextLevelDataPanel()
  {
    nextLevelRadiusAttackField.gameObject.SetActive(false);
    nextLevelDamageField.gameObject.SetActive(false);
  }
  public void ShowNextLevelDataPanel()
  {
    nextLevelRadiusAttackField.gameObject.SetActive(true);
    nextLevelDamageField.gameObject.SetActive(true);
  }
  public void RefreshUpdateButton()
  {
    if (!castle) return;
    CastleLevelSystem castleLevelSystem = castle.GetComponent<CastleLevelSystem>();
    bool canUpdate = TowerUpgradeService.Instance.CanUpdate(castleLevelSystem);
    updateButton.interactable = canUpdate;

  }

  private void OnLevelChanged(int level)
  {
    RefreshAll();
  }

  private void RefreshAll()
  {
    CastleLevelSystem castleLevelSystem = castle.GetComponent<CastleLevelSystem>();
    levelFieldText.text = "Level : " + (castleLevelSystem.currentTowerLevel + 1);
    updateButton.interactable =
        TowerUpgradeService.Instance.CanUpdate(castleLevelSystem);
    costUpdateField.text = castleLevelSystem.UpdateCost.ToString();
  }
}