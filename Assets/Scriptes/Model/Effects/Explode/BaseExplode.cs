using System;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class BaseExplode : MonoBehaviour, IReleasable
{
    [SerializeField] private Timer _timer;
    [SerializeField] private float _duration;

    public event Action<IReleasable> Released;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    private void OnEnable()
    {
        _timer.EndTime += Release;
        _timer.Run(_duration);
    }

    private void OnDisable()
    {
        _timer.EndTime -= Release;
    }

    private void Release()
    {
        Released?.Invoke(this);
    }
}