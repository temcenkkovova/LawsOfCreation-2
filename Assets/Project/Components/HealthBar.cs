using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  [SerializeField] private Image fillImage;
  private Canvas canvas;
  public Health health;

  void OnEnable()
  {
    if (health == null) return;
    health.OnHealthChanged += SetHealth;
  }
  void OnDisable()
  {
    if (health == null) return;
    health.OnHealthChanged -= SetHealth;
  }

  public void SetHealth(float value)
  {

    float percentage = value / health.maxHealth;
    float result = Mathf.Clamp01(percentage);
    fillImage.fillAmount = result;
  }


  void Awake()
  {
    canvas = GetComponent<Canvas>();
    canvas.worldCamera = Camera.main;
  }
  void LateUpdate()
  {

    transform.forward = Camera.main.transform.forward;
  }
}
