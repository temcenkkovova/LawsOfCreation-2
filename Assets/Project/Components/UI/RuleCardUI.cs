using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RuleCardUI : MonoBehaviour, IPointerClickHandler
{
  private RuleConfig ruleConfig;
  public static event Action<RuleConfig> OnRuleChoose;
  public TMP_Text titleTextField;
  public TMP_Text descriptionTextField;
  public Image imageField;
  public TMP_Text btnText;
  public TMP_Text difficultyField;
  public RuleCardVFX ruleCardVFX;
  private bool activeRule;
  public void OnPointerClick(PointerEventData eventData)
  {
    if (activeRule)
      OnRuleChoose?.Invoke(ruleConfig);

  }

  public void SetActive(bool status)
  {
    activeRule = status;

  }

  void Start()
  {

  }
  public void SetData(RuleConfig rule, int indexWave)
  {


    ruleConfig = rule;
    titleTextField.text = rule.title;
    descriptionTextField.text = rule.smallDescription;
    imageField.sprite = rule.icon;
    if (difficultyField != null)
    {
      difficultyField.text = rule.minWave.ToString();
    }

    if (btnText != null)
    {
      btnText.text = rule.ruleType.ToString();
    }

    if (ruleCardVFX != null)
    {

      ruleCardVFX.ApplyStyle(rule.minWave <= indexWave);
    }



  }
}