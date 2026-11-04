using UnityEngine;
[CreateAssetMenu(menuName = "Castle/Castle")]
public class CastleConfig : ScriptableObject
{
  public float Health;
  public AttackConfig attackConfig;
  public AudioConfig audioConfig;

}