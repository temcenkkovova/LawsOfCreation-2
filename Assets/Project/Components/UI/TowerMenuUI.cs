using UnityEngine;
using UnityEngine.EventSystems;

public class TowerMenuUI : MonoBehaviour
{
  public GameObject panel;
  public static TowerMenuUI Instance;
  public PanelMenuItemsUI panelMenuItemsUI;
  private bool ignoreNextClick;
  private void Awake()
  {
    Instance = this;
    panel.SetActive(false);
  }
  public void Open(Castle castle)
  {

    Vector3 panelPos = Camera.main.WorldToScreenPoint(castle.transform.position);
    panel.transform.position = panelPos;
    panelMenuItemsUI.Init(castle);

    panel.SetActive(true);
    ignoreNextClick = true;

  }
  public void Close()
  {
    panel.SetActive(false);

    CastleSelectionController.Instance.current = null;
  }
  private void Update()
  {

    if (!panel.activeSelf) return;
    if (ignoreNextClick)
    {
      ignoreNextClick = false;
      return;
    }

    if (Input.GetMouseButtonDown(0))
    {

      if (!IsPointerOverUI())
      {

        CastleSelectionController.Instance.Clear();
      }
    }
  }
  private bool IsPointerOverUI()
  {
    return EventSystem.current.IsPointerOverGameObject();
  }
}