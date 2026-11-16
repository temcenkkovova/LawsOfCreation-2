using System.Collections.Generic;
using UnityEngine;

public class TowersRulesManager : MonoBehaviour
{
  public static TowersRulesManager Instance;
  public List<RuleConfig> ruleConfigs; // config that changes tower`s stats
  public float ReduceBuildCostPercentage { get; private set; }
  public float DamageIncreasePercentage { get; private set; }
  public float AttackIntervalIncreasePercentage { get; private set; }
  //public float 
  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }

    Instance = this;

  }

  public void AddConfig(RuleConfig ruleConfig)
  {
    if (ruleConfigs.Contains(ruleConfig)) return;
    ruleConfigs.Add(ruleConfig);
  }
  public void RemoveConfig(RuleConfig ruleConfig)
  {
    if (!ruleConfigs.Contains(ruleConfig)) return;
    ruleConfigs.Remove(ruleConfig);
  }
  public void SetBuildCostReducePercentage(float percentage)
  {
    ReduceBuildCostPercentage = percentage;
  }
  public void SetTowersDamageIncreasePercentage(float percentage)
  {
    DamageIncreasePercentage = percentage;
  }
  public void SetTowersAttackIntervalIncreasePercentage(float percentage)
  {
    AttackIntervalIncreasePercentage = percentage;
  }

}