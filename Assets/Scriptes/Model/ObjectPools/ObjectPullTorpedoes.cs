using UnityEngine;

public class ObjectPullTorpedoes : ObjectPull<Torpedo>
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private ObjectPullExplosion _objectPullExplosion;

    public override Torpedo GetObject()
    {
        Torpedo torpedo = base.GetObject();
        AddScoreCounter addScoreCounter = _scoreCounter.AddScoreForEnemy;

        torpedo.Subscribe(addScoreCounter);
        torpedo.SetObjectPullExplosion(_objectPullExplosion);

        return torpedo;
    }

    public override void PutObject(IReleasable released)
    {
        Torpedo torpedo = released as Torpedo;
        AddScoreCounter addScoreCounter = _scoreCounter.AddScoreForEnemy;

        torpedo.UnSubscribe(addScoreCounter);

        base.PutObject(released);
    }

    public delegate void AddScoreCounter(IInteractable interactable);
}

