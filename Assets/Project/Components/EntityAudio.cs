using UnityEngine;

public class EntityAudio : MonoBehaviour
{
  private AudioConfig config;

  public void Init(AudioConfig audioConfig)
  {
    config = audioConfig;
  }

  void OnEnable()
  {
    GetComponent<Health>().OnDamaged += PlayHit;
  }

  void OnDisable()
  {
    GetComponent<Health>().OnDamaged -= PlayHit;
  }

  void PlayHit(DamageInfo info)
  {
    var clip = config.hitClips[Random.Range(0, config.hitClips.Length)];
    float pitch = Random.Range(config.pitchMin, config.pitchMax);

    AudioService.Instance.PlayAt(new Vector3(0, 0, 0), clip, config.volume, pitch);
  }
}