using System;
using UnityEngine;

public class SecondsLive : MonoBehaviour
{
    [SerializeField] private float _seconds;

    public event Action<float> Changed;

    private bool _isStart;

    public void Reset()
    {
        _seconds = 0;

        Changed?.Invoke(_seconds);
    }

    private void Update()
    {
        if (_isStart)
        {
            _seconds += Time.deltaTime;
            Changed?.Invoke(_seconds);
        }
    }

    public void StartSeconds(bool isStart)
    {
        _isStart = isStart;
    }
}
