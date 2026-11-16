using UnityEngine;
public enum RuleType
{
  BUFF,
  DANGER,

}

public enum RuleDifficulties
{
  Easy,
  Medium,
  Hard
}
[CreateAssetMenu(menuName = "Rules/Rule")]

public abstract class RuleConfig : ScriptableObject, IRule
{
  public int indexRule;
  public string description;
  public string deBuffDescription;
  public string title;
  public Sprite icon;
  public string buffDescription;

  public RuleType ruleType;
  public int minWave;
  public RuleDifficulties difficulty;
  public float rewardMultiply;

  public RuleStyleConfig styleConfig;
  public abstract void Apply(Enemy enemy);

}