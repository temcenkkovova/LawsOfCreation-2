using UnityEngine;
using UnityEngine.EventSystems;

public class CastleClickManager : MonoBehaviour
{
  [SerializeField] private LayerMask clickableMask;
  private BuildSpot currentBuildStop;
  private ITowerSelectable currentTowerSelected;
  private Castle selectedCastle;
  private void ClearTowerSelection()
  {
    if (selectedCastle != null)
      selectedCastle.OnSell -= HandleTowerSold;

    // Проверяем существование Unity-компонента за интерфейсом.
    if (currentTowerSelected is MonoBehaviour component && component != null)
      currentTowerSelected.UnSelected();

    currentTowerSelected = null;
    selectedCastle = null;
  }
  private void HandleTowerSold(Castle soldCastle)
  {
    ClearTowerSelection();
  }
  void Update()
  {

    if (Input.GetMouseButtonDown(0))
    {
      if (EventSystem.current != null &&
            EventSystem.current.IsPointerOverGameObject())
      {
        return;
      }
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      if (Physics.Raycast(ray, out hit, 250f, clickableMask))
      {


        // Tower upgrade menu
        ITowerSelectable newTowerSelected = hit.collider.GetComponent<ITowerSelectable>();
        if (newTowerSelected != null)
        {
          if (newTowerSelected == currentTowerSelected)
            return;
          currentBuildStop?.HideSpotUIMenu();
          currentBuildStop = null;

          ClearTowerSelection();


          currentTowerSelected = newTowerSelected;
          selectedCastle = newTowerSelected as Castle;
          if (selectedCastle != null)
            selectedCastle.OnSell += HandleTowerSold;

          currentTowerSelected.Selected();
          return;
        }
        // Build slot place
        BuildSpot newSpot = hit.collider.GetComponent<BuildSpot>();
        if (newSpot != null)
        {
          if (newSpot == currentBuildStop) return;
          Debug.Log("qs");
          ClearTowerSelection();
          currentBuildStop?.HideSpotUIMenu();
          currentBuildStop = newSpot;
          currentBuildStop.ClickSpot();
          return;
        }
      }
      else
      {

        if (currentBuildStop != null) currentBuildStop.HideSpotUIMenu();


        currentBuildStop = null;
        ClearTowerSelection();
      }
    }
  }
  private void OnDisable()
  {
    ClearTowerSelection();

    if (currentBuildStop != null)
      currentBuildStop.HideSpotUIMenu();

    currentBuildStop = null;
  }
}