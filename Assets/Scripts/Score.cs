


using TMPro;
using UnityEngine;

namespace Remembering
{
  public class Score : MonoBehaviour
  {

    private static Score _instance;

    [SerializeField] private TMP_Text _text;
    private int points = 0;

    private void Awake()
    {
      if (_instance != null && _instance != this)
      {
        Destroy(this);
        return;
      }
      _instance = this;
    }


    public static void ModifyScore(int points) => _instance.ModifyScoreInt(points);

    private void ModifyScoreInt(int points)
    {
      this.points += points;
      _text.text = $"{this.points}";
    }

  }
}
