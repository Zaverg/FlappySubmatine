using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _countPoints;

    public event Action<int> Changed;

    public void Add(IInteracteble interacteble)
    {
        if (interacteble is EnemySubmarine)
        {
            _countPoints += 10;
        }

        Changed?.Invoke(_countPoints);
    }

    public void Reset()
    {
        _countPoints = 0;
        Changed?.Invoke(_countPoints);
    }
}
