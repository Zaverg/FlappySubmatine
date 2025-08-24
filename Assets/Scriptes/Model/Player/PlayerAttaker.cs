using UnityEngine;

public class PlayerAttaker : Attaker
{
    private bool _canAttack = true;

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

    private void CanAttack()
    {
        _canAttack = true;
    }
}
