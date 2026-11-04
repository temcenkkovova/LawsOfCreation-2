
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

    Vector3 dir = currentTarget.transform.position - rotateTransform.position;
    dir.y = 0f;
    rotateTransform.rotation = Quaternion.Slerp(rotateTransform.rotation, Quaternion.LookRotation(dir), rotateSpeed * Time.deltaTime);
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