
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RuleCard : MonoBehaviour
{
  public Image iconRule;
  public TMP_Text title;
  public TMP_Text typeOfRule;
  public TMP_Text description;
  public TMP_Text secondDescription;
  public TMP_Text tipOfRule;
  private RuleManager RuleManager;
  private RuleConfig config;
  public GameObject SelectedBtn;
  public GameObject RemoveBtn;
  public GameObject closeCardBtn;
  public Transform leftCardSectionGrid;
  public RuleCardUI leftCardPrefab;
  private OpenRuleCardVFX ruleCardVFX;
  public Image detailImage;
  public event Action OnClose;

  void Awake()
  {
    ruleCardVFX = GetComponent<OpenRuleCardVFX>();
  }
  void Start()
  {
    RuleManager.OnSelectedRuleChanged += HideSelectedButton;
    RuleManager.OnAllRulesChanged += ShowSelectedButton;
  }
  void OnDisable()
  {
    RuleManager.OnSelectedRuleChanged -= HideSelectedButton;
    RuleManager.OnAllRulesChanged -= ShowSelectedButton;
  }
  public void Init(RuleConfig rule, RuleManager manager)
  {
    RuleCardUI leftCard = Instantiate(leftCardPrefab, leftCardSectionGrid);
    leftCard.SetData(rule, 0);
    iconRule.sprite = rule.icon;
    detailImage.sprite = rule.icon;
    title.text = rule.title;
    typeOfRule.text = rule.ruleType.ToString();
    description.text = rule.description;
    secondDescription.text = rule.smallDescription;
    tipOfRule.text = "Combine with Regen to make a durable tank";
    RuleManager = manager;
    config = rule;
    if (ruleCardVFX != null) ruleCardVFX.ApplyStyle(rule.styleConfig);
  }

  public void HandleCardClick()
  {
    RuleManager.SelectedRule(config);
  }
  public void HandleClickRemove()
  {
    RuleManager.RemoveSelectedRule(config);
  }

  public void HideSelectedButton()
  {
    SelectedBtn.SetActive(false);
    RemoveBtn.SetActive(true);
  }
  public void ShowSelectedButton()
  {
    SelectedBtn.SetActive(true);
    RemoveBtn.SetActive(false);
  }
  public void CloseCard()
  {
    OnClose?.Invoke();
  }
}