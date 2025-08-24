using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public class Torpedo : MonoBehaviour, IReliseble, IInteracteble
{                                  
    [SerializeField] private float _damage;

    private CollisionHandler _collisionHandler;
    private Vector2 _direction;
    private float _speed;

    public float Damage => _damage;

    public event Action<IReliseble> Realesed;
    public event Action<Torpedo, IInteracteble> Exploded;
    public event Action<Torpedo, IInteracteble> Hit;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();

        _collisionHandler.CollisionDetected += Explode;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
    }

    private void Explode(IInteracteble interacteble)
    {
        Hit?.Invoke(this, interacteble);
        Exploded?.Invoke(this, interacteble);
        Realesed?.Invoke(this);
    }

    public void SetParams(float speed, Vector2 direction)
    {
        _speed = speed;
        _direction = direction;

        transform.localScale = new Vector3(_direction.x > 0 ? -1 : 1, transform.localScale.y, transform.localScale.z);
    }
}
