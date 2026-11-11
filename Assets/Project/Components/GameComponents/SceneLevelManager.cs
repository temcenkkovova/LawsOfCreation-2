using UnityEngine;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using System;

public class SceneLevelManager : MonoBehaviour
{
  public static SceneLevelManager Instance { get; private set; }
  private int currentSceneIndex = 1; // Start from 1 because I`m already at the first level
  public List<string> scenes = new List<string>();
  public event Action OnNextScene;
  public event Action OnRestartGame;

  public void TryStartNextScene()
  {

    StartScene(ref currentSceneIndex);
  }

  public void StartScene(ref int index)
  {
    if (index > scenes.Count - 1) return;
    OnNextScene?.Invoke();
    SceneManager.LoadScene(scenes[index]);
    index++;
  }
  public void ResetSceneIndex()
  {

    currentSceneIndex = 1;


  }
  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
  }
}