using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private float _maxCountLives;
    [SerializeField] private float _currentCountLives;

    public float MaxCountLives => _maxCountLives;
    public float CurrentCountLives => _currentCountLives;

    public event Action<float> HealthChanged;
    public event Action GameOver;

    public void Reset()
    {
        _currentCountLives = _maxCountLives;
    }

    private void Awake()
    {
        _currentCountLives = _maxCountLives;
    }

    public void TakeDamage(float damage)
    {
        _currentCountLives = Mathf.Max(_currentCountLives - damage, 0);

        HealthChanged?.Invoke(_currentCountLives);

        if (_currentCountLives <= 0)
        {
            _exploder.Spawn();
            GameOver?.Invoke();
        }
    }
}
