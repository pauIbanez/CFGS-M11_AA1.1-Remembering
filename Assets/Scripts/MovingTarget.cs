

using System.Collections.Generic;
using UnityEngine;

namespace Remembering
{

  public class MovingTarget : MonoBehaviour
  {
    [SerializeField] private Transform[] _path;
    [SerializeField] private float _speed;

    public short currentIndex = 0;


    private void Update()
    {

      transform.position = Vector3.MoveTowards(transform.position, _path[currentIndex].position, _speed * Time.deltaTime);
      if (Vector3.Distance(transform.position, _path[currentIndex].position) <= 0.1f) if (currentIndex >= _path.Length - 1) currentIndex = 0; else currentIndex++;
    }
  }

}
