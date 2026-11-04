using TMPro;
using UnityEngine;

public class GameStateUI : MonoBehaviour
{
  //public TMP_Text textField;
  void Start()
  {
    ShowGameState(GameStateController.Instance.CurrentState);

    GameStateController.Instance.OnGameStateChanged += ShowGameState;

  }

  void OnDisable()
  {
    GameStateController.Instance.OnGameStateChanged -= ShowGameState;
  }
  public void ShowGameState(GameState state)
  {
    // textField.text = state.ToString();
  }
}