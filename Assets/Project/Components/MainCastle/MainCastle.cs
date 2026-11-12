using UnityEngine;

public class MainCastle : MonoBehaviour
{

  public CastleConfig castleConfig;
  private MainCastleHealth health;
  private Attack attack;
  private FindEnemySystem findEnemySystem;
  private CastleAttackController castleAttackController;
  private AttackAudio attackAudio;
  private EntityAudio hitAudio;
  public EnemyWaveController enemyWaveController;


  void Awake()
  {
    health = GetComponent<MainCastleHealth>();
    findEnemySystem = GetComponent<FindEnemySystem>();
    castleAttackController = GetComponent<CastleAttackController>();
    attack = GetComponent<Attack>();
    attackAudio = GetComponent<AttackAudio>();
    hitAudio = GetComponent<EntityAudio>();
  }

  void Start()
  {
    Init();

    if (!GameStateController.Instance.IsStartData)
    {
      InitHealthPreviousLocation(GameStateController.Instance.MainCastleHealth);
    }
  }

  public void Init()
  {
    if (health == null || attack == null || findEnemySystem == null) return;
    health.Init(castleConfig.Health);
    attack.InitConfigs(castleConfig.attackConfig, castleConfig.audioConfig);
    findEnemySystem.SetConfigData(castleConfig.attackConfig, enemyWaveController as IEnemyProvider);
    castleAttackController.SetConfig(castleConfig.attackConfig);
    attackAudio.Init(castleConfig.audioConfig);
    hitAudio.Init(castleConfig.audioConfig);
  }

  public void InitHealthPreviousLocation(float value)
  {
    health.Init(value);
  }

}