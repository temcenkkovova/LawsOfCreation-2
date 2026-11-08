
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllRulesController : MonoBehaviour
{
  public Button ruleSlotPrefab;
  public Transform gridParent;
  public List<RuleConfig> rules = new();
  public GameFlowController gameFlowController;
  private int cardsToShow = 4;


  void Start()
  {
    RebuildRules();
  }

  public void RebuildRules()
  {

    foreach (Transform child in gridParent)
      Destroy(child.gameObject);


    List<RuleConfig> copyListRules = new List<RuleConfig>(rules);
    int currentWave = gameFlowController.currentIndexWave + 1;
    Debug.Log("tt");
    Debug.Log(copyListRules.Count);
    for (int i = 0; i < cardsToShow; i++)
    {
      int randomNumberIndex = Random.Range(0, copyListRules.Count);

      RuleConfig ruleConfig = copyListRules[randomNumberIndex];
      copyListRules.RemoveAt(randomNumberIndex);
      bool active = gameFlowController.currentIndexWave + 1 >= ruleConfig.minWave;
      Button slot = Instantiate(ruleSlotPrefab, gridParent);
      slot.GetComponent<RuleCardUI>().SetData(ruleConfig, currentWave);
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

  void OnEnable()
  {

  }
}


