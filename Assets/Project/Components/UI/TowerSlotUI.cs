using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerSlotUI : MonoBehaviour
{
  public TMP_Text nameTowerField;
  public TMP_Text costField;
  public Sprite towerIcon;

  public BuildSpot buildSpot;
  public Image iconField;
  public TMP_Text rangeField;
  public TMP_Text damageField;
  public GameObject panel;
  public LayerMask layerMask;


  void OnEnable()
  {
    panel.SetActive(false);
    if (buildSpot != null)
    {
      buildSpot.OnSlotClicked += ShowSlotPanel;
      buildSpot.OnClose += HideSlotPanel;
    }

  }

  void Start()
  {
    panel.SetActive(false);

  }

  public void ShowSlotPanel()
  {
    Debug.Log("qaas");
    panel.SetActive(true);
    //nameTowerField.text = config.name;
    //costField.text = config.cost.ToString();
    damageField.text = "20";
    rangeField.text = "2";

  }
  public void HideSlotPanel()
  {
    panel.SetActive(false);
  }

  void OnDisable()
  {
    buildSpot.OnSlotClicked -= ShowSlotPanel;
    buildSpot.OnClose -= HideSlotPanel;
  }
}