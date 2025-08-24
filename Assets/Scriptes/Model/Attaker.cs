using UnityEngine;

public abstract class Attaker : MonoBehaviour
{
    [SerializeField] protected Timer Timer;
    [SerializeField] protected ObjectPullTorpedos ObjectPull;
    [SerializeField] protected float TorpedoSpeed;
    [SerializeField] protected Vector2 Direction;
    [SerializeField] protected float Delay;
    [SerializeField] protected int LayerNumber;

    protected Torpedo Torpedo;

    public virtual void Attack()
    {
        Torpedo = ObjectPull.GetObject();

        Torpedo.gameObject.SetActive(true);

        Torpedo.transform.position = transform.position;
        Torpedo.transform.rotation = transform.rotation;

        Torpedo.gameObject.layer = LayerNumber;

        Torpedo.SetParams(TorpedoSpeed, Direction);
    }
}
