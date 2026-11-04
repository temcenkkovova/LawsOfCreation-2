using UnityEngine;

public class ChooseRuleCard : MonoBehaviour
{
  private RuleConfig rule;
  private RuleManager ruleManager;
  public void Init(RuleConfig config, RuleManager manager)
  {
    rule = config;
    ruleManager = manager;
  }
  public void HandleCardClick()
  {
    if (ruleManager == null) return;

    ruleManager.RemoveSelectedRule(rule);
  }
}