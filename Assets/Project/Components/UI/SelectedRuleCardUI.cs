
using UnityEngine;
using UnityEngine.UI;

public class SelectedRuleCardUI : MonoBehaviour
{
  private RuleConfig config;
  public Image imageField;
  public Image borderImage;
  public void Init(RuleConfig config)
  {
    this.config = config;
    imageField.sprite = config.icon;
    Color color = config.styleConfig.baseBtnBorder;
    color.a = 255f;
    imageField.color = color;
    borderImage.color = color;
  }


}