using UnityEngine;

public class PlayerSubmarine : Submarine, IInteractable
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerAttacker _attacker;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _inputReader.Moving += _mover.Move;
        _inputReader.Attack += _attacker.Attack;
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _inputReader.Moving -= _mover.Move;
        _inputReader.Attack -= _attacker.Attack;
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    protected override void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Border)
        {
            _health.TakeDamage(_health.CurrentCountLives);
        }
        else if (interactable is Torpedo)
        {
            Torpedo torpedo = interactable as Torpedo;
            _health.TakeDamage(torpedo.Damage);
        }
        else if (interactable is EnemySubmarine)
        {
            _health.TakeDamage(_health.CurrentCountLives);
        }
    }
}
