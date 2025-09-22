using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private GameInput _gameInput;

    public Action Moving;
    public Action Attack;

    private void Awake()
    {
        _gameInput = new GameInput();
    }

    private void OnEnable()
    {
        _gameInput.Enable();
        _gameInput.Player.Move.performed += OnMove;
        _gameInput.Player.Attack.performed += OnAttack;
    }
    
    private void OnDisable()
    {
        _gameInput.Player.Move.performed -= OnMove;
        _gameInput.Player.Attack.performed -= OnAttack;

        _gameInput.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Moving?.Invoke();
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        Attack?.Invoke();
    }
}
