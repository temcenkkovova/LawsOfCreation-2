using UnityEngine;

public class AttackAudio : MonoBehaviour
{
  private AudioConfig config;

  public void Init(AudioConfig audioConfig)
  {
    config = audioConfig;


  }

  void OnEnable()
  {
    GetComponent<CastleShoot>().OnShoot += PlayShoot;
  }

  void OnDisable()
  {
    GetComponent<CastleShoot>().OnShoot -= PlayShoot;
  }

  void PlayShoot()
  {
    var clip = config.shootClip[Random.Range(0, config.shootClip.Length)];
    float pitch = Random.Range(config.pitchMin, config.pitchMax);

    AudioService.Instance.PlayAt(new Vector3(0, 0, 0), clip, config.volume, pitch);
  }
}