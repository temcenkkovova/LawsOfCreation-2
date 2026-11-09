using UnityEngine;

public class LevelSceneController : MonoBehaviour
{
  public MainCastleHealth mainCastleHealth;

  // This system needs to save data before leaving the game .
  //  So I need to save data during starting every scene (Level-scene) . When the new level-scene open I save the data (health , gold , rules)

  public void SaveCastleHealth()
  {
    float health = mainCastleHealth.CurrentHealth;
    PlayerPrefs.SetFloat("CastleHealth", health);
  }
  public void SaveRules()
  {


  }
  public void SaveGold()
  {

  }
  public void SaveSettings()
  {
    PlayerPrefs.Save();
  }

  public void SaveData()
  {
    SaveCastleHealth();
    SaveGold();
    SaveRules();
    SaveSettings();
  }
}