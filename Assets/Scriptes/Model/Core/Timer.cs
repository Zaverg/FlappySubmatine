using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action EndTime;

    private Coroutine _coroutine;

    public void Reset()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Run(float seconds)
    {
        _coroutine = StartCoroutine(StartTimer(seconds));
    }

    private IEnumerator StartTimer(float seconds)
    {
        while (seconds > 0)
        {
            seconds -= Time.deltaTime;
            yield return null;
        }

        EndTime?.Invoke();
    }
} 
