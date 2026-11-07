using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildMenuUI : MonoBehaviour
{
  public static BuildMenuUI Instance;

  public GameObject panel;
  public TowerBuildController buildController;

  public TMP_Text nameTowerField;
  public TMP_Text costField;
  public Sprite towerIcon;
  public TowerSlot towerSlot;
  public Image iconField;
  public TMP_Text rangeField;
  public TMP_Text damageField;


  // It`s a build menu UI 
  public SpotManager spotManager;

  private void Awake()
  {
    Instance = this;
    panel.SetActive(false);
  }
  void OnEnable()
  {
    buildController.OnTowerBuilded += Close;
  }
  void OnDisable()
  {
    buildController.OnTowerBuilded -= Close;
  }

  public void Open(BuildSpot spot)
  {
    panel.SetActive(true);
    // nameTowerField.text = config.name;
    // costField.text = config.cost.ToString();
    damageField.text = "20";
    rangeField.text = "2";


    panel.SetActive(true);
  }

  public void Close()
  {
    panel.SetActive(false);
    //spotManager.SetCurrentSpot(null);
    buildController.ClearSection();
  }

  private void Update()
  {

    if (!panel.activeSelf) return;

    if (Input.GetMouseButtonDown(0))
    {

      if (!IsPointerOverUI())
      {

        Close();
      }
    }
  }
  private bool IsPointerOverUI()
  {
    return EventSystem.current.IsPointerOverGameObject();
  }

}
