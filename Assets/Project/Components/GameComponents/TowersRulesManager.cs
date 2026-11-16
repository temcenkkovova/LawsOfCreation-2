using System;
using System.Collections.Generic;
using UnityEngine;

public class TowersRulesManager : MonoBehaviour
{
  public static TowersRulesManager Instance;
  public List<RuleConfig> ruleConfigs; // config that changes tower`s stats
  public float ReduceBuildCostPercentage { get; private set; } = 0f;
  public float DamageIncreasePercentage { get; private set; } = 0f;
  public float AttackIntervalIncreasePercentage { get; private set; } = 0f;

  public event Action<float> OnAttackIntervalPercentageChanged;
  public event Action<float> OnDamagePercentageChanged;
  public event Action<float> OnBuildCostPercentageChanged;

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
    OnBuildCostPercentageChanged?.Invoke(ReduceBuildCostPercentage);
  }
  public void SetTowersDamageIncreasePercentage(float percentage)
  {
    DamageIncreasePercentage = percentage;
    OnDamagePercentageChanged?.Invoke(DamageIncreasePercentage);
  }
  public void SetTowersAttackIntervalIncreasePercentage(float percentage)
  {
    AttackIntervalIncreasePercentage = percentage;
    OnAttackIntervalPercentageChanged?.Invoke(AttackIntervalIncreasePercentage);
  }

}