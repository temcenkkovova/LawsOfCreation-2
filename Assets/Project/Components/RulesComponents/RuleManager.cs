using System;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
  private ChooseRuleController chooseRuleController;
  private AllRulesController allRulesController;
  public GameFlowController gameFlowController;

  public RuleCard prefabCard;
  public Transform gridParent;
  public event Action OnSelectedRuleChanged;
  public event Action OnAllRulesChanged;
  private RuleCard currentCard;

  void Awake()
  {
    chooseRuleController = GetComponent<ChooseRuleController>();
    allRulesController = GetComponent<AllRulesController>();
  }

  public void SelectedRule(RuleConfig rule)
  {
    if (chooseRuleController.currentChooseRules.Contains(rule)) return;
    if (chooseRuleController.currentChooseRules.Count >= 3)
    {
      return;
    }
    chooseRuleController.SetRule(rule);
    OnSelectedRuleChanged?.Invoke();
    allRulesController.ChangeRulesList(rule);
    CloseCurrentCard();
  }
  public void RemoveSelectedRule(RuleConfig removeRule)
  {
    if (chooseRuleController.currentChooseRules.Contains(removeRule))
    {

      chooseRuleController.currentChooseRules.Remove(removeRule);
      chooseRuleController.RebuildSelectedRules();
      allRulesController.AddRuleToList(removeRule);
      OnAllRulesChanged?.Invoke();
    }

  }

  public void OpenSelectedRule(RuleConfig rule)
  {
    foreach (Transform child in gridParent)
      Destroy(child.gameObject);
    currentCard = Instantiate(prefabCard, gridParent);
    currentCard.OnClose += CloseCurrentCard;
    ChangeGridStatus(true);
    currentCard.Init(rule, this);
    if (chooseRuleController.currentChooseRules.Contains(rule))
    {
      currentCard.HideSelectedButton();
    }
  }

  public void CloseCurrentCard()
  {
    currentCard.OnClose -= CloseCurrentCard;
    currentCard.gameObject.SetActive(false);
    ChangeGridStatus(false);
  }
  public void ChangeGridStatus(bool status)
  {
    gridParent.gameObject.SetActive(status);
  }
}