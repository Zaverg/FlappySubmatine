using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Exploder), typeof(EnemyAttacker), typeof(EnemyMover))]
public class EnemySubmarine : Submarine, IReleasable, IInteractable
{
    [SerializeField] private CollisionHandler _collisionHandler;

    private Exploder _exploder;
    private EnemyMover _mover;
    private EnemyAttacker _attacker;

    public event Action<IReleasable> Released;

    private void Awake()
    {
        _exploder = GetComponent<Exploder>();
        _mover = GetComponent<EnemyMover>();
        _attacker = GetComponent<EnemyAttacker>();
    }

    public void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    public void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    protected override void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Border)
        {
            Released?.Invoke(this);
        }
        else if (interactable is Torpedo)
        {
            _exploder.Spawn();
            Released?.Invoke(this);
        }
    }

    public void SetParams(float speed)
    {
        _mover.SetParams(speed);
    }

    public void SetObjectPulls(ObjectPullTorpedoes objectPullTorpedoes, ObjectPullExplosion objectPullExplosion)
    {
        _attacker.SetObjectPullTorpedoes(objectPullTorpedoes);
        _exploder.SetExplosionPool(objectPullExplosion);
    }
}
