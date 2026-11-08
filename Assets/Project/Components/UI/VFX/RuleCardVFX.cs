
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RuleCardVFX : MonoBehaviour
{

  public TMP_Text difficultyText;
  public Button slotButton;
  public GameObject lockPanel;

  public void ApplyStyle(bool ruleDifficulty)
  {

    if (slotButton == null) return;

    slotButton.interactable = ruleDifficulty;
    lockPanel.SetActive(!ruleDifficulty);

  }
}