using UnityEngine;
using UnityEngine.InputSystem;

namespace Remembering
{

  public class Movement : MonoBehaviour
  {
    [Header("Config")]
    [Tooltip("The sensibility multiplayer to use (horizontal,vertical)")]
    [SerializeField] private Vector2 _sensibility = new Vector2(0.1f, 0.1f);
    [Tooltip("The y angle clamps in deg as (min,max)")]
    [SerializeField] private Vector2 _yClamps = new Vector2(-150f, -37f);

    [Header("Objects")]
    [SerializeField] private Transform _turret;
    [SerializeField] private Transform _pivot;


    private float _yaw;
    private float _pitch;

    private void Start()
    {
      _yaw = _turret.localEulerAngles.y;
      _pitch = 0f;

      Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
      if (Mouse.current == null) return;

      Vector2 delta = Mouse.current.delta.ReadValue() * _sensibility;
      if (delta == Vector2.zero) return;

      _yaw = Mathf.Repeat(_yaw + delta.x, 360f);
      _pitch = Mathf.Clamp(_pitch - delta.y, _yClamps.x, _yClamps.y);

      _turret.localRotation = Quaternion.Euler(0f, _yaw, 0f);
      _pivot.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
    }
  }
}
