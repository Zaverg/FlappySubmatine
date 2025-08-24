using UnityEngine;
using System;

public abstract class Submarine : MonoBehaviour
{
    public event Action<Torpedo, IInteracteble> Hit;

    protected abstract void ProcessCollision(IInteracteble interacteble);
 
}
