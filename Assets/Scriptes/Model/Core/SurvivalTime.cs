using System;
using UnityEngine;

public class SurvivalTime : MonoBehaviour
{
    [SerializeField] private float _elapsedTime;

    public event Action<float> Changed;

    private bool _isStart;

    public void Reset()
    {
        _elapsedTime = 0;

        Changed?.Invoke(_elapsedTime);
    }

    private void Update()
    {
        if (_isStart)
        {
            _elapsedTime += Time.deltaTime;
            Changed?.Invoke(_elapsedTime);
        }
    }

    public void SetTimerActive(bool isStart)
    {
        _isStart = isStart;
    }
}
