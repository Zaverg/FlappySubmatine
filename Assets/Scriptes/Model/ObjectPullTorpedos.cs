using UnityEngine;

public class ObjectPullTorpedos : ObjectPull<Torpedo> 
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private ExplodeSpawner ExplodeSpawner;

    public override Torpedo GetObject()
    {
        Torpedo torpedo = base.GetObject();
        torpedo.GetComponent<CollisionHandler>().CollisionDetected += _scoreCounter.Add;
        torpedo.Exploded += ExplodeSpawner.Spawn;

        return torpedo;
    }

    public override void PutObject(IReliseble relised)
    {
        Torpedo torpedo = relised as Torpedo;
        torpedo.GetComponent<CollisionHandler>().CollisionDetected -= _scoreCounter.Add;
        torpedo.Exploded += ExplodeSpawner.Spawn;

        base.PutObject(relised);
    }
}

