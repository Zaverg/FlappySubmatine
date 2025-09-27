using UnityEngine;

public class ObjectPullTorpedoes : ObjectPull<Torpedo>
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private ObjectPullExplosion _objectPullExplosion;

    public override Torpedo GetObject()
    {
        Torpedo torpedo = base.GetObject();

        torpedo.CollisionHandler.CollisionDetected += _scoreCounter.AddScoreForEnemy;
        torpedo.SetObjectPullExplosion(_objectPullExplosion);

        return torpedo;
    }

    public override void PutObject(IReleasable released)
    {
        Torpedo torpedo = released as Torpedo;
        torpedo.CollisionHandler.CollisionDetected -= _scoreCounter.AddScoreForEnemy;

        base.PutObject(released);
    }
}