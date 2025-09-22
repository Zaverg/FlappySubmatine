using UnityEngine;

public class EnemyAttacker : Attacker
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

    public void SetParams(ObjectPullTorpedoes objectPullTorpedoes)
    {
        ObjectPull = objectPullTorpedoes; 
    }
}
