using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

/* It`s managing with active choose rules */
public class ChooseRuleController : MonoBehaviour
{

  [NonSerialized] public List<RuleConfig> currentChooseRules = new();
  public int maxCountCurrentRules = 3;
  public GameObject ruleSlotPrefab;
  public Transform gridParent;
  private RuleManager ruleManager;

  void Start()
  {
    ruleManager = GetComponent<RuleManager>();
  }

  public void SetRule(RuleConfig rule)
  {
    if (currentChooseRules.Contains(rule)) return;
    currentChooseRules.Add(rule);
    RebuildSelectedRules();
  }
  public void RemoveCurrentRules()
  {
    currentChooseRules.Clear();
  }
  public void RebuildSelectedRules()
  {
    foreach (Transform child in gridParent)
      Destroy(child.gameObject);


    foreach (var item in currentChooseRules)
    {
      GameObject slot = Instantiate(ruleSlotPrefab, gridParent);
      slot.GetComponent<SelectedRuleCardUI>().Init(item);
      slot.GetComponent<ChooseRuleCard>().Init(item, ruleManager);

    }
    for (int i = currentChooseRules.Count; i < maxCountCurrentRules; i++)
    {
      GameObject slot = Instantiate(ruleSlotPrefab, gridParent);
    }
  }
}