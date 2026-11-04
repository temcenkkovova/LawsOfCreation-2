using UnityEngine;

public enum AttackType
{
  Mile,
  Range,

}

public abstract class AttackConfig : ScriptableObject
{
  public float attackDamage;
  public float attackInterval;
  public AttackType attackType;
  public float radiusAttack;

}