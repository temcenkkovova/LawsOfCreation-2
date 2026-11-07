using UnityEngine;

public class CastleClickManager : MonoBehaviour
{
  [SerializeField] private LayerMask clickableMask;
  private BuildSpot currentBuildStop;
  private bool isOpen = false;
  void Update()
  {

    if (Input.GetMouseButtonDown(0))
    {

      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      if (Physics.Raycast(ray, out hit, 100f, clickableMask))
      {
        // Башня
        var tower = hit.collider.GetComponent<ITowerSelectable>();
        if (tower != null)
        {
          tower.Selected();

        }

        // Место строительства
        currentBuildStop = hit.collider.GetComponent<BuildSpot>();

        if (currentBuildStop != null && !isOpen)
        {

          currentBuildStop.ClickSpot();
          isOpen = true;

        }
      }
      else
      {
        if (currentBuildStop != null)
        {
          currentBuildStop.HideSpotUIMenu();
          isOpen = false;
        }
      }
    }
  }
}