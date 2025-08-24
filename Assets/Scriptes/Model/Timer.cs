using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action EndTime;

    public void Run(float seconds)
    {
        StartCoroutine(StartTimer(seconds));
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
