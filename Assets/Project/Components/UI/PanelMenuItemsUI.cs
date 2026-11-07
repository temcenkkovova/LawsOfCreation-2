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
    // if (castleLevelSystem != null)
    //castleLevelSystem.OnLevelChanged += OnLevelChanged;

    //if (towerUpgradeService != null) towerUpgradeService.OnUpgrade += ShowTowerData;

    RefreshAll();
  }

  public void ShowTowerData()
  {
    levelFieldText.text = "Level : " + (castleLevelSystem.currentTowerLevel + 1);
    costUpdateField.text = castleLevelSystem.UpdateCost.ToString();
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