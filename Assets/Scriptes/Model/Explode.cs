using System;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class Explode : MonoBehaviour, IReliseble
{
    [SerializeField] private Timer _timer;
    [SerializeField] private float _second;

    public event Action<IReliseble> Realesed;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    private void OnEnable()
    {
        _timer.EndTime += Realese;
        _timer.Run(_second);
    }

    private void OnDisable()
    {
        _timer.EndTime -= Realese;
    }

    private void Realese()
    {
        Realesed?.Invoke(this);
    }
}