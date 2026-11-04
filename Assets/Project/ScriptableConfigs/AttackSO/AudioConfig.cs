using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Health")]
public class AudioConfig : ScriptableObject
{
  public AudioClip[] hitClips;
  public AudioClip[] deathClips;
  public AudioClip[] shootClip;
  public float volume = 1f;
  public float pitchMin = 0.95f;
  public float pitchMax = 1.05f;
}