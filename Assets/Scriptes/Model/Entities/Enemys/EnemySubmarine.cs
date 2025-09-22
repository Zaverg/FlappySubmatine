using System;
using UnityEngine;

[RequireComponent(typeof(Exploder))]
public class EnemySubmarine : Submarine, IReleasable, IInteractable
{
    [SerializeField] private CollisionHandler _collisionHandler;

    private Exploder _exploder;

    public event Action<IReleasable> Released;

    private void Awake()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;

        _exploder = GetComponent<Exploder>();
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
}
