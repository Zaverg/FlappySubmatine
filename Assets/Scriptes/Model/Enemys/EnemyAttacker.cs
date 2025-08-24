using UnityEngine;

public class EnemyAttacker : Attaker
{
    private void Awake()
    {
        Timer.EndTime += Attack;
    }

    private void OnEnable()
    {
        Timer.Run(Delay);
    }

    public override void Attack()
    {
        base.Attack();
    }

    public void SetParams(ObjectPullTorpedos objectPullTorpedos)
    {
        ObjectPull = objectPullTorpedos; 
    }
}
