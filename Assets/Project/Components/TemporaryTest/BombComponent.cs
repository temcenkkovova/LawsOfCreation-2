using UnityEngine;

public class BombComponent : MonoBehaviour
{
  public float delay = 2f;
  public float radius = 2.5f;
  public int damage = 150;
  public LayerMask targetMask;

  private void Start()
  {
    Invoke(nameof(Explode), delay);
  }

  private void Explode()
  {
    Collider2D[] hits = Physics2D.OverlapCircleAll(
      transform.position,
      radius,
      targetMask
    );

    foreach (var hit in hits)
    {
      // hit.GetComponent<IDamageable>()?.TakeDamage(damage);  // это уже когда будет возможность получать урон или герою или замку
    }

    Destroy(gameObject);
  }
}
