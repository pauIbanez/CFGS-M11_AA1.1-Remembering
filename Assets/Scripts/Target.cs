

using System.Collections;
using UnityEngine;

namespace Remembering
{

  [RequireComponent(typeof(Collider))]
  public class Target : MonoBehaviour
  {
    [Header("Config")]
    [SerializeField] private float _respawnTime = 3f;
    [SerializeField] private int _pointsOnDestroy = 100;

    [Header("Objects")]
    [SerializeField] private GameObject _main;
    [SerializeField] private GameObject _broken;


    [Header("Destruction")]
    [SerializeField] private float _impactForce = 5f;
    [SerializeField] private float _impactRadius = 1f;



    private Collider _collider;


    private void Awake()
    {
      _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (!_main.activeSelf || !collision.gameObject.CompareTag("Bullet")) return;
      StartCoroutine(Break(collision.GetContact(0).point));
    }

    private IEnumerator Break(Vector3 impactPoint)
    {
      _main.SetActive(false);
      _collider.enabled = false;

      Score.ModifyScore(_pointsOnDestroy);

      GameObject debris = Instantiate(_broken, _broken.transform.position, _broken.transform.rotation);
      debris.SetActive(true);
      Destroy(debris, _respawnTime);

      yield return new WaitForFixedUpdate();

      foreach (Rigidbody piece in debris.GetComponentsInChildren<Rigidbody>())
        piece.AddExplosionForce(_impactForce, impactPoint, _impactRadius, 0f, ForceMode.Impulse);


      yield return new WaitForSeconds(_respawnTime);

      _main.SetActive(true);
      _collider.enabled = true;
    }

  }
}
