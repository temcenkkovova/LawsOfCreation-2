using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
  private Projectile projectile;
  private bool isTriggered = false;
  void Start()
  {
    projectile = GetComponent<Projectile>();
  }
  void OnEnable()
  {
    isTriggered = false;
  }

  public void OnTriggerEnter(Collider other)
  {

    bool target = other.tag == "Enemy";
    if (!target || isTriggered) return;

    projectile.attack.ReleaseAttack(other.GetComponent<IDamageable>());
    isTriggered = true;
    Destroy(transform.gameObject);

  }
}

