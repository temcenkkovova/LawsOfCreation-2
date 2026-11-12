using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{


  //public TMP_Text titleTextField;

  public Image imageField;


  public void SetData(RuleConfig rule)
  {
    //titleTextField.text = rule.title;
    imageField.sprite = rule.icon;
  }
}