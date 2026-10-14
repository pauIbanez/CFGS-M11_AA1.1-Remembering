

using UnityEngine;

namespace Remembering
{

  public class Target : MonoBehaviour
  {

    [SerializeField] private GameObject _main;
    [SerializeField] private GameObject _broken;


    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.tag != "Bullet") return;
      _main.SetActive(false);
      _broken.SetActive(true);
      enabled = false;

      Destroy(gameObject, 5f);
    }

  }
}
