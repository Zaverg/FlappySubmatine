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

    public void SetObjectPullTorpedoes(ObjectPullTorpedoes objectPullTorpedoes)
    {
        ObjectPull = objectPullTorpedoes; 
    }
}
