using UnityEngine;

public class GamePauseUI : MonoBehaviour
{
  public GameObject pauseMenu;



  void Start()
  {
    GameStateController.Instance.OnPauseChanged += ActivePauseMenu;
  }

  void OnDisable()
  {
    GameStateController.Instance.OnPauseChanged -= ActivePauseMenu;
  }
  public void ActivePauseMenu(bool state)
  {

    pauseMenu.SetActive(state);
  }
}