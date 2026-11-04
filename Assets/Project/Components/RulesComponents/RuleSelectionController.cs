using UnityEngine;

public class RuleSelectionController : MonoBehaviour
{
  [SerializeField] private RuleManager ruleManager;

  void OnEnable()
  {
    RuleCardUI.OnRuleChoose += ruleManager.OpenSelectedRule;
  }
  void OnDisable()
  {
    RuleCardUI.OnRuleChoose -= ruleManager.OpenSelectedRule;
  }

}