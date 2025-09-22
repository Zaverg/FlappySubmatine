using UnityEngine;

public abstract class Attacker : MonoBehaviour
{
    [SerializeField] protected Timer Timer;
    [SerializeField] protected ObjectPullTorpedoes ObjectPull;
    [SerializeField] protected float TorpedoSpeed;
    [SerializeField] protected Vector2 Direction;
    [SerializeField] protected float Delay;
    [SerializeField] protected int TargetLayer;

    protected Torpedo Torpedo;

    public virtual void Attack()
    {
        Torpedo = ObjectPull.GetObject();

        Torpedo.gameObject.SetActive(true);

        Torpedo.transform.position = transform.position;
        Torpedo.transform.rotation = transform.rotation;

        Torpedo.gameObject.layer = TargetLayer;

        Torpedo.SetParams(TorpedoSpeed, Direction);
    }
}
