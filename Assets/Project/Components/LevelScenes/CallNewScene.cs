using UnityEngine;

public class CallNewScene : MonoBehaviour
{
  public void CallScene()
  {
    SceneLevelManager.Instance.TryStartNextScene();
  }
}