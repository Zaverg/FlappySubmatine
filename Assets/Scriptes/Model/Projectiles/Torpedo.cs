using System;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler), typeof(Exploder))]
public class Torpedo : MonoBehaviour, IReleasable, IInteractable
{                                  
    [SerializeField] private float _damage;

    private CollisionHandler _collisionHandler;
    private Exploder _exploder;
    private Vector2 _direction;
    private float _speed;

    public float Damage => _damage;

    public event Action<IReleasable> Released;
    public event Action<Torpedo, IInteractable> Hit;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _exploder = GetComponent<Exploder>();

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

    private void Explode(IInteractable interactable)
    {
        Hit?.Invoke(this, interactable);
        _exploder.Spawn();
        Released?.Invoke(this);
    }

    public void SetParams(float speed, Vector2 direction)
    {
        _speed = speed;
        _direction = direction;

        transform.localScale = new Vector3(_direction.x > 0 ? -1 : 1, transform.localScale.y, transform.localScale.z);
    }
}
