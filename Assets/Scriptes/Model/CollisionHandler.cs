using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<IInteracteble> CollisionDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteracteble interacteble))
        {
            CollisionDetected?.Invoke(interacteble);
        }
    }
}
