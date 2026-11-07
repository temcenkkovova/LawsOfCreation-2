using UnityEngine;
using UnityEngine.EventSystems;

public class TowerMenuUI : MonoBehaviour
{


  public PanelMenuItemsUI panelMenuItemsUI;
  public Castle castle;
  private TowerUpgradeService towerUpgradeService;
  private Canvas canvas;
  void OnEnable()
  {
    if (castle != null)
    {
      castle.OnSelected += Open;
      castle.OnUnSelected += Close;
    }

  }

  void Awake()
  {
    canvas = GetComponent<Canvas>();
    canvas.worldCamera = Camera.main;
  }
  private void Start()
  {
    towerUpgradeService = castle.GetComponent<TowerUpgradeService>();
    panelMenuItemsUI.gameObject.SetActive(false);


  }
  public void Open()
  {
    panelMenuItemsUI.Init(castle);
    panelMenuItemsUI.gameObject.SetActive(true);
  }
  public void Close()
  {
    panelMenuItemsUI.gameObject.SetActive(false);

    //CastleSelectionController.Instance.current = null;
  }

  public void HandleClickUpdate()
  {

    TowerUpgradeService.Instance.TryUpgradeTower(castle);
  }
  public void HandleClickSell()
  {

    castle.SellItem();
  }

  void OnDisable()
  {
    if (castle != null)
    {
      castle.OnSelected -= Open;
      castle.OnUnSelected -= Close;
    }

  }
}