using System;
using UnityEngine;

public class BuildSpot : MonoBehaviour
{
  public bool isFree = true;
  [NonSerialized] public Castle spotCastle;
  public SpriteRenderer visualSprite;
  private bool readToBuild;

  void Start()
  {
    GameEconomy.Instance.coinRewards.OnChangeRewardCoin += HasCoinToBuild;
    HasCoinToBuild();
  }
  public void ClickSpot()
  {
    if (!readToBuild) return;
    BuildMenuUI.Instance.Open(this);
  }
  public void ShowTowerSpot(bool newStatus)
  {
    isFree = newStatus;
    gameObject.SetActive(isFree);
  }
  public void SetSpotCastle(Castle castle)
  {
    spotCastle = castle;
  }
  public void HasCoinToBuild()
  {
    if (GameEconomy.Instance.HasEnough(50))
    {

      visualSprite.color = Color.white;
      readToBuild = true;
    }
    else
    {
      visualSprite.color = Color.gray;
      readToBuild = false;
    }
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
