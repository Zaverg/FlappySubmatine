using UnityEngine;

public class PlayerSubmarine : Submarine, IInteracteble
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerAttaker _attacker;
    [SerializeField] private CollisionHandler _collisonHandler;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _inputReader.Moving += _mover.Move;
        _inputReader.Attack += _attacker.Attack;
        _collisonHandler.CollisionDetected += ProcessCollision;
    }

    protected override void ProcessCollision(IInteracteble interacteble)
    {
        if (interacteble is Border)
        {
            _health.TakeDamage(_health.CurrentCountLives);
            Debug.Log("GameOver");
        }
        else if (interacteble is Torpedo)
        {
            Debug.Log("Torpedo");
            Torpedo torpedo = interacteble as Torpedo;
            _health.TakeDamage(torpedo.Damage);
        }
        else if (interacteble is EnemySubmarine)
        {
            _health.TakeDamage(_health.CurrentCountLives);
            Debug.Log("GameOver");
        }
    }
}
