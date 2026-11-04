using TMPro;
using UnityEngine;

public class MainCastleHealthUI : MonoBehaviour
{
  public TMP_Text healthField;
  public MainCastleHealth health;

  void Start()
  {
    if (!health) return;
    health.OnHealthChanged += ShowNewHealth;
    ShowNewHealth(health.currentHealth);
  }

  public void ShowNewHealth(float amountHealth)
  {
    healthField.text = amountHealth.ToString();
  }

  void OnDisable()
  {
    if (!health) return;
    health.OnHealthChanged -= ShowNewHealth;
  }
}