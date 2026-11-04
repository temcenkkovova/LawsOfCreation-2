using UnityEngine;
using UnityEngine.EventSystems;

public class BuildMenuUI : MonoBehaviour
{
  public static BuildMenuUI Instance;

  public GameObject panel;
  public TowerBuildController buildController;


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
    spotManager.SetCurrentSpot(spot);


    Vector3 panelPos = Camera.main.WorldToScreenPoint(spot.transform.position);

    panel.transform.position = panelPos;


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
