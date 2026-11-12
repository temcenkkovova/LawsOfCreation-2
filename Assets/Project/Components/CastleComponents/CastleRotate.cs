
using UnityEngine;

public class CastleRotate : MonoBehaviour
{
  public float rotateSpeed = 5f;
  private Transform rotateTransform;
  private Enemy currentTarget;
  private FindEnemySystem findEnemySystem;


  void Awake()
  {

    findEnemySystem = GetComponent<FindEnemySystem>();
    findEnemySystem.OnEnemy += SetEnemyTarget;
  }
  public void SetNewTransform(Transform tr)
  {
    rotateTransform = tr;

  }

  void Update()
  {

    if (currentTarget == null || rotateTransform == null) return;
    Vector3 worldDir =
        currentTarget.transform.position - rotateTransform.position;
    Transform parent = rotateTransform.parent;

    Vector3 localDir = parent != null
        ? parent.InverseTransformDirection(worldDir)
        : worldDir;


    localDir.z = 0f;

    if (localDir.sqrMagnitude < 0.0001f)
      return;


    float targetAngle =
        Mathf.Atan2(localDir.x, -localDir.y) * Mathf.Rad2Deg;

    float angle = Mathf.LerpAngle(
        rotateTransform.localEulerAngles.z,
        targetAngle,
        rotateSpeed * Time.deltaTime
    );


    rotateTransform.localRotation = Quaternion.Euler(0f, 0f, angle);
  }

  public void SetEnemyTarget(Enemy enemy)
  {
    currentTarget = enemy;
  }

  void OnDisable()
  {
    if (findEnemySystem)
      findEnemySystem.OnEnemy -= SetEnemyTarget;
  }


}