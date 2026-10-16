
using UnityEngine;
using UnityEngine.InputSystem;

namespace Remembering
{


  public class CameraMovement : MonoBehaviour
  {
    [SerializeField] private GameObject _turret;
    [SerializeField] private float _distanceToTurret;


    [Tooltip("The sensibility multiplayer to use (horizontal,vertical)")]
    [SerializeField] private Vector2 _sensibility = new Vector2(0.1f, 0.1f);


    private float _yaw;
    private float _pitch;

    private void Update()
    {
      MoveAround();
      AvoidCollision();
    }

    private void AvoidCollision()
    {
      Vector3 inverseDir = transform.forward * -1;

      RaycastHit hit;
      if (Physics.Raycast(_turret.transform.position, inverseDir, out hit, _distanceToTurret))
      {
        transform.position = hit.point;
      }
      else
      {
        transform.position = _turret.transform.position + inverseDir * _distanceToTurret;
      }
    }


    private void MoveAround()
    {
      Vector2 dir = Vector2.zero;
      if (Keyboard.current.wKey.isPressed) dir.y += 1;
      if (Keyboard.current.sKey.isPressed) dir.y -= 1;
      if (Keyboard.current.aKey.isPressed) dir.x -= 1;
      if (Keyboard.current.dKey.isPressed) dir.x += 1;

      _yaw = Mathf.Repeat(_yaw + dir.x * _sensibility.x * Time.deltaTime, 360f);
      _pitch = Mathf.Clamp(_pitch + dir.y * _sensibility.y * Time.deltaTime, -10f, 80f);

      transform.rotation = Quaternion.Euler(_pitch, _yaw, 0);
    }

  }
}
