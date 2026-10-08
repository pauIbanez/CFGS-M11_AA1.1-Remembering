
using UnityEngine;
using UnityEngine.InputSystem;

namespace Remembering
{
  public class Shoot : MonoBehaviour
  {
    [Header("Config")]
    [SerializeField] private float _muzzleForce;

    [Header("Objects")]
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private GameObject _projectile;


    private void Update()
    {
      if (!Keyboard.current.spaceKey.wasPressedThisFrame) return;

      GameObject projectile = Instantiate(_projectile, _muzzlePoint.position, _muzzlePoint.rotation);
      projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * _muzzleForce, ForceMode.Impulse);
    }
  }
}
