using TMPro;
using UnityEngine;

public abstract class Timer : MonoBehaviour
{
    public delegate void TimerEvents();
    public TimerEvents HasEnd;

    private TextMeshProUGUI _time;
    private float _startTime;
    private float _currentTime;

    private void Start()
    {
        _time = GetComponent<TextMeshProUGUI>();
    }

    public void StartAt(float time)
    {
        _startTime = time;
    }

    private void Update()
    {
        if (_startTime - _currentTime > 0f)
        {
            _currentTime += Time.deltaTime;
            if (_startTime - _currentTime <= 0f) 
            {
                _currentTime = 0f;
                _startTime = 0f;
                HasEnd?.Invoke();
            }
            _time.text = GetTimeText((int)(_startTime - _currentTime));
        }
    }

    protected abstract string GetTimeText(int time);
}
