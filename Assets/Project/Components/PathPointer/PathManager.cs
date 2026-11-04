using UnityEngine;

public class PathManager : MonoBehaviour
{
  public Path path1;
  // public Path path2;

  public Path GetPath(PathType pathType)
  {
    if (pathType == PathType.Path1) return path1;
    // if (pathType == PathType.Path2) return path2;
    return path1;

  }
}