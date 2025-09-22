using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private List<int> _points = new List<int>();
    [SerializeField] private int _currentScore;

    public event Action<int> Changed;

    public void AddScoreForEnemy(IInteractable interactable)
    {
        if (interactable is EnemySubmarine)
        {
            _currentScore += _points[0];
        }

        Changed?.Invoke(_currentScore);
    }

    public void Reset()
    {
        _currentScore = 0;
        Changed?.Invoke(_currentScore);
    }
}
