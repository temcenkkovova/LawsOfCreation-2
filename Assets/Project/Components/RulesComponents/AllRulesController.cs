using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllRulesController : MonoBehaviour
{
  public Button ruleSlotPrefab;
  public Transform gridParent;
  public List<RuleConfig> rules = new();
  public GameFlowController gameFlowController;

  void Start()
  {
    RebuildRules();
  }

  public void RebuildRules()
  {
    foreach (Transform child in gridParent)
      Destroy(child.gameObject);

    foreach (var item in rules)
    {
      bool active = gameFlowController.currentIndexWave + 1 >= item.minWave;
      Button slot = Instantiate(ruleSlotPrefab, gridParent);
      slot.GetComponent<RuleCardUI>().SetData(item, gameFlowController.currentIndexWave + 1);
      slot.GetComponent<RuleCardUI>().SetActive(active);
      slot.interactable = active;
    }
  }

  public void ChangeRulesList(RuleConfig rule)
  {
    if (rules.Contains(rule)) rules.Remove(rule);
    RebuildRules();
  }
  public void AddRuleToList(RuleConfig rule)
  {
    if (!rules.Contains(rule)) rules.Add(rule);
    RebuildRules();
  }
}


