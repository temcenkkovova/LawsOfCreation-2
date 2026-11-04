using System;
using UnityEngine;

public class CoinRewards : MonoBehaviour
{
  private float totalCoin;
  [SerializeField] private float startCoins = 500f;

  public float TotalCoin => totalCoin;
  public event Action OnChangeRewardCoin;

  void Start()
  {
    totalCoin = startCoins;
    OnChangeRewardCoin?.Invoke();
  }
  public void ChangeBalance(float amount)
  {
    totalCoin += amount;
    OnChangeRewardCoin?.Invoke();
  }
}