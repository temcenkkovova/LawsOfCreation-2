using UnityEngine;

public class SideBarRulesUI : MonoBehaviour
{
  public Transform gridParent;
  public GameObject prefab;
  public ChooseRuleController chooseRuleController;
  public WaveController waveController;

  void Start()
  {
    waveController.OnWaveStarted += BuildRulesUI;
  }

  public void BuildRulesUI(int index)
  {
    if (chooseRuleController == null || chooseRuleController.currentChooseRules == null) return;
    foreach (Transform child in gridParent)
      Destroy(child.gameObject);

    foreach (var item in chooseRuleController.currentChooseRules)
    {
      GameObject slot = Instantiate(prefab, gridParent);
      slot.GetComponent<CardUI>().SetData(item);

    }
  }
}