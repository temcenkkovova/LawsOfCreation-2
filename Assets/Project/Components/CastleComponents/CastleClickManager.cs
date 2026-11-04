using UnityEngine;

public class CastleClickManager : MonoBehaviour
{
  [SerializeField] private LayerMask clickableMask;
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
          return;
        }

        // Место строительства
        var buildSpot = hit.collider.GetComponent<BuildSpot>();

        if (buildSpot != null)
        {

          buildSpot.ClickSpot();
          return;
        }
      }
    }
  }
}