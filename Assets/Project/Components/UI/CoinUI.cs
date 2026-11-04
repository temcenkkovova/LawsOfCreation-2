using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
  public TMP_Text textField;
  public CoinRewards coinRewards;

  void Start()
  {
    ShowRewards();
    coinRewards.OnChangeRewardCoin += ShowRewards;
  }

  public void ShowRewards()
  {
    textField.text = coinRewards.TotalCoin.ToString();
  }

}