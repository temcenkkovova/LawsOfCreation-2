using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
  public GameObject menuNavBtn;
  public GameObject rulesMenuPanel;
  public GameObject rulePrefab;
  public Transform gridParent;
  public List<RuleConfig> ruleConfigs;
  public GameFlowController gameFlowController;


  void Start()
  {
    SetRules();
  }
  public void BackToMenu()
  {
    rulesMenuPanel.SetActive(false);
    menuNavBtn.SetActive(true);
  }

  public void OpenRules()
  {
    rulesMenuPanel.SetActive(true);
    menuNavBtn.SetActive(false);
  }

  public void SetRules()
  {
    if (ruleConfigs == null) return;
    foreach (var item in ruleConfigs)
    {
      GameObject slot = Instantiate(rulePrefab, gridParent);
      slot.GetComponent<RuleCardUI>().SetData(item, 0);
    }
  }
}