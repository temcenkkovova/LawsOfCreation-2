using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  [SerializeField] private Image fillImage;

  public void SetHealth(float value)
  {
    fillImage.fillAmount = Mathf.Clamp01(value);
  }

  void LateUpdate()
  {
    // всегда смотрит в камеру
    transform.forward = Camera.main.transform.forward;
  }
}
