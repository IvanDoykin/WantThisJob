using UnityEngine;
using UnityEngine.UI;

public class BonusView : MonoBehaviour
{
    private Timer _timer;
    private Image _image;

    public Timer Timer => _timer;

    public void Initialize(Bonus bonus, float time)
    {
        _timer = GetComponentInChildren<Timer>();
        _image = GetComponent<Image>();

        _timer.StartAt(time);
        _image.sprite = bonus.Avatar;
    }
}
