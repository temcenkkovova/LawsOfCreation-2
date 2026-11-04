using UnityEngine;

public class GameControl : MonoBehaviour
{
  private GameController inputController;
  private bool active = true;

  void Awake()
  {
    inputController = new GameController();
  }
  void Start()
  {
    GameStateController.Instance.OnGameStateChanged += OnGameStateChanged;
  }

  void Update()
  {
    if (inputController.Game.Pause.WasPressedThisFrame())
    {
      GameStateController.Instance.SetPause(!GameStateController.Instance.IsPause);
    }
  }

  private void OnGameStateChanged(GameState state)
  {

    active = state == GameState.Gameplay;
  }

  private void OnEnable()
  {
    inputController.Enable();
  }

  private void OnDisable()
  {
    inputController.Disable();
  }
}