using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    public event Action StartGame;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(() => StartGame?.Invoke());
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveAllListeners();
    }
}
