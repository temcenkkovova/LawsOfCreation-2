using UnityEngine;

public class SceneController : MonoBehaviour
{
  public void QuitGame()
  {
    Application.Quit();
#if UNITY_EDITOR //quit from game
    UnityEditor.EditorApplication.isPlaying = false;
#endif
  }
}