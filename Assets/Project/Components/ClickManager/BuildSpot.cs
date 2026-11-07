using System;
using UnityEngine;

public class BuildSpot : MonoBehaviour
{
  public bool isFree = true;
  [NonSerialized] public Castle ownSpotCastle;
  public SpriteRenderer visualSprite;
  private bool canBuild;
  public event Action OnSlotClicked;
  public event Action OnClose;
  public TowerBuildController towerBuildController;

  void Start()
  {
    GameEconomy.Instance.coinRewards.OnChangeRewardCoin += HasCoinToBuild;

    HasCoinToBuild();
    if (towerBuildController != null)
      towerBuildController.OnTowerBuilded += HideSpot;
  }

  void OnDisable()
  {
    GameEconomy.Instance.coinRewards.OnChangeRewardCoin -= HasCoinToBuild;
    if (towerBuildController != null)
      towerBuildController.OnTowerBuilded -= HideSpot;
  }
  public void ClickSpot()
  {
    if (!canBuild) return;
    OnSlotClicked?.Invoke();
  }
  public void HideSpot()
  {
    canBuild = false;


    gameObject.SetActive(false);
  }
  public void HideSpotUIMenu()
  {
    OnClose?.Invoke();
  }

  public void SetSpotCastle(Castle castle)
  {
    ownSpotCastle = castle;
  }
  public void HasCoinToBuild()
  {
    if (GameEconomy.Instance.HasEnough(50))
    {

      visualSprite.color = Color.white;
      canBuild = true;
    }
    else
    {
      visualSprite.color = Color.gray;
      canBuild = false;
    }
  }

  public void HandleClickBuildButton()
  {
    towerBuildController.BuildTower(this);
  }
  // void OnMouseEnter()
  // {
  //   visualSprite.color = Color.yellow;
  // }
  // void OnMouseExit()
  // {
  //   visualSprite.color = Color.green;
  // }
}
