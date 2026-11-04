using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  public Vector3 Move;
  public float BaseSpeed;
  public float CurrentSpeed;
  public Vector3 Direction;
  [NonSerialized] public Transform Target;
  public event Action<float> OnSpeedChanged;
  private List<Vector3> points;
  private int currentIndexPathPoint = 0;


  public void SetDataMovement(float baseSpeed, Transform transformTarget, List<Vector3> path)
  {

    BaseSpeed = baseSpeed;
    CurrentSpeed = baseSpeed;

    Direction = (transformTarget.position - transform.position).normalized; // могу один раз записать позицию таргета ибо он не двигается
    Direction.y = 0f;
    Direction.x = 0f;
    Target = transformTarget;
    OnSpeedChanged?.Invoke(CurrentSpeed);
    points = path;
  }
  public void SetSpeedMultiplier(float multiplier)
  {
    CurrentSpeed = BaseSpeed * multiplier;
    OnSpeedChanged?.Invoke(CurrentSpeed);
  }

  void Update()
  {
    if (CurrentSpeed <= 0f || points == null) return;
    MoveByPath();

  }

  private void MoveByPath()
  {
    if (currentIndexPathPoint > points.Count) return;
    Vector3 target = new Vector3(points[currentIndexPathPoint].x, points[currentIndexPathPoint].y, points[currentIndexPathPoint].z);

    Vector3 delta = target - transform.position;
    delta.y = 0f;
    if (delta.sqrMagnitude < 0.0001f)
    {
      currentIndexPathPoint++;
      return;
    }
    Vector3 dir = delta.normalized;

    transform.position += dir * CurrentSpeed * Time.deltaTime;
    if (dir.sqrMagnitude > 0.0001f)
      transform.rotation = Quaternion.LookRotation(dir);

    if (Vector3.Distance(transform.position, target) < 0.1f) currentIndexPathPoint++;
  }

}