using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    public event Action Restarted;

    private void OnEnable()
    {
        _restartButton?.onClick.AddListener(Reset);
    }

    private void OnDisable()
    {
        _restartButton?.onClick.RemoveListener(Reset);
    }

    private void Reset()
    {
        Restarted?.Invoke();
        gameObject.SetActive(false);
    }
}
