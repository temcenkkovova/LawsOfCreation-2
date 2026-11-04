using System;
using UnityEngine;

public class GameEconomy : MonoBehaviour
{
  public static GameEconomy Instance;
  public CoinRewards coinRewards;
  public float sellMultiplier = 0.7f;
  public event Action OnSellTower;
  void Awake()
  {
    Instance = this;
  }
  public bool TrySpend(int price)
  {
    if (HasEnough(price))
    {
      coinRewards.ChangeBalance(-price);
      return true;
    }
    else
    {
      return false;
    }
  }
  public void Sell(ISellable item)
  {
    if (item == null) return;
    int refund = Mathf.RoundToInt(item.GetSellValue() * sellMultiplier);
    coinRewards.ChangeBalance(+refund);
    item.OnSell();
    OnSellTower?.Invoke();
  }

  public bool HasEnough(int amount)
  {
    return coinRewards.TotalCoin >= amount ? true : false;
  }
}