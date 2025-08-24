using System;
using UnityEngine;

public class EnemySubmarine : Submarine, IReliseble, IInteracteble
{
    [SerializeField] private CollisionHandler _collisionHandler;

    public event Action<IReliseble> Realesed;

    private void Awake()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    protected override void ProcessCollision(IInteracteble interacteble)
    {
        if (interacteble is Border)
        {
            Debug.Log("Realesed");
            Realesed?.Invoke(this);
        }
        else if (interacteble is Torpedo)
        {
            
            Realesed?.Invoke(this);
        }
    }
}
