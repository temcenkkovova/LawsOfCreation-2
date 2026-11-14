using DG.Tweening;
using UnityEngine;

public class MainCastleAnimations : MonoBehaviour
{
  private Sequence castleSequence;
  private MainCastleHealth castleHealth;
  public Transform visualTr;

  private float timer = 0;
  void Awake()
  {
    castleHealth = GetComponent<MainCastleHealth>();
  }
  void Start()
  {
    if (castleHealth != null)
      castleHealth.OnDamaged += PlayScaleAnimation;
  }

  public void PlayScaleAnimation(DamageInfo damageInfo)
  {

    if (timer <= 0)
    {

      castleSequence.Kill();
      castleSequence = DOTween.Sequence();
      castleSequence.Insert(0f, visualTr.transform.DOScale(1.2f, 0.5f)).SetEase(Ease.InQuad);
      castleSequence.Insert(0.5f, visualTr.transform.DOScale(1f, 0.3f)).SetEase(Ease.InQuad);
      timer = 0.5f;
    }

  }
  void Update()
  {
    if (timer > 0)
    {
      timer -= Time.deltaTime;
    }
  }
  void OnEnable()
  {

  }

  void OnDisable()
  {
    if (castleHealth != null)
      castleHealth.OnDamaged -= PlayScaleAnimation;
  }
}