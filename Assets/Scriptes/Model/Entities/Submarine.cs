using UnityEngine;
using System;

public abstract class Submarine : MonoBehaviour
{
    public event Action<Torpedo, IInteractable> OnHit;

    protected abstract void ProcessCollision(IInteractable interactable);
 
}
