using System;
using UnityEngine;

public class SpotManager : MonoBehaviour
{
  [NonSerialized] public BuildSpot CurrentBuildSpot;
  public void SetCurrentSpot(BuildSpot spot)
  {

    CurrentBuildSpot = spot;

  }
}