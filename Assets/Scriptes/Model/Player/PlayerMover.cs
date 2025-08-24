using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : Mover
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rigidbody2d;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private Vector2 _restartPosition;

    public void Reset()
    {
        transform.position = _restartPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2d.linearVelocity = Vector2.zero;
    }

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        _restartPosition = transform.position;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public override void Move()
    {
        _rigidbody2d.linearVelocity = Vector3.zero;

        _rigidbody2d.linearVelocity = new Vector2(0, _tapForce);
        transform.rotation = _maxRotation;
    }

    public void OnMove(bool isMove)
    {
        _rigidbody2d.simulated = isMove;
    }
}
