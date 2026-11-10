using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneUI : MonoBehaviour
{
  public GameFlowController gameFlowController;
  public Button changeSceneBtn;
  public Button startWaveBtn;
  public Image darkScreenImage;
  public Sequence darkSequence;
  public GameObject panel;

  void Start()
  {
    if (gameFlowController == null) return;
    gameFlowController.OnLastWave += ChangeBtnsState;


  }

  void OnDisable()
  {
    if (gameFlowController == null) return;
    gameFlowController.OnLastWave -= ChangeBtnsState;
  }
  public void ChangeBtnsState()
  {
    changeSceneBtn.gameObject.SetActive(true);
    startWaveBtn.gameObject.SetActive(false);

  }

  public void DarkScreen()
  {
    panel.SetActive(true);
    darkSequence.Kill();
    darkSequence = DOTween.Sequence();
    darkSequence.Insert(0f, darkScreenImage.DOFade(1f, 0.8f)).SetEase(Ease.InQuad).OnComplete(Test);
    //arrivalSequence.Append(arrivalGlow.DOFade(0f, 0.16f).SetEase(Ease.InQuad));

  }
  public void Test()
  {
    SceneLevelManager.Instance.TryStartNextScene();
  }
}