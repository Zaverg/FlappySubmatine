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

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _exploder = GetComponent<Exploder>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += Explode;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= Explode;
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
        _exploder.Spawn();
        Released?.Invoke(this);
    }

    public void SetParams(float speed, Vector2 direction, float rotationY)
    {
        _speed = speed;
        _direction = direction;

        transform.Rotate(transform.localRotation.x, rotationY, transform.localRotation.z);
    }

    public void Subscribe(Delegate _scoreCounter)
    {
        if (_scoreCounter is Action<IInteractable>)
            _collisionHandler.CollisionDetected += _scoreCounter as Action<IInteractable>;
    }

    public void UnSubscribe(Delegate _scoreCounter)
    {
        if (_scoreCounter is Action<IInteractable>)
            _collisionHandler.CollisionDetected -= _scoreCounter as Action<IInteractable>;
    }

    public void SetObjectPullExplosion(ObjectPullExplosion objectPullExplosion)
    {
        _exploder.SetExplosionPool(objectPullExplosion);
    }
}
