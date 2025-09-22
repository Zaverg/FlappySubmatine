using UnityEngine;

public class PlayerAttacker : Attacker
{
    [SerializeField] private bool _canAttack = true;

    public void Reset()
    {
        Timer.Reset();
        _canAttack = true;
    }

    private void Awake()
    {
        Timer.EndTime += CanAttack;
    }

    public override void Attack()
    {
        if (_canAttack)
        {
            Timer.Run(Delay);
            _canAttack = false;
            
            base.Attack();
        }
    }

    public void OnAttack(bool canAttack)
    {
        _canAttack = canAttack;
    }

    private void CanAttack()
    {
        _canAttack = true;
    }
}
