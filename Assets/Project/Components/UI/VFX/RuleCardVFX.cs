
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RuleCardVFX : MonoBehaviour
{
  public Image baseGlow;
  public Image baseBorder;
  public Image glowInside;
  public Image baseBackground;
  public Image backgroundImageTitle;
  public Image backgroundImageTitleGlow;
  public Image imageTitle;
  public Image baseBtn;
  public Image baseBtnBorder;
  public Image baseBtnGlow;
  public TMP_Text btnText;
  public TMP_Text difficultyText;

  public void ApplyStyle(RuleStyleConfig styleConfig, bool ruleDifficulty)
  {



    //baseBackground.color = styleConfig.baseBackground;


    //imageTitle.color = styleConfig.imageTitle;
    //baseBtn.color = styleConfig.baseBtn;

    //btnText.color = styleConfig.btnText;

    if (difficultyText)
    {
      //difficultyText.color = ruleDifficulty ? Color.green : Color.red;
    }

  }
}