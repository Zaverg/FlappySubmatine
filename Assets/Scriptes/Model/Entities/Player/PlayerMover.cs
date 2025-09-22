using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : Mover
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rigidbody2D;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private Vector2 _restartPosition;

    public void Reset()
    {
        transform.position = _restartPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2D.linearVelocity = Vector2.zero;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

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
        _rigidbody2D.linearVelocity = Vector3.zero;

        _rigidbody2D.linearVelocity = new Vector2(0, _tapForce);
        transform.rotation = _maxRotation;
    }

    public void OnMove(bool isMove)
    {
        _rigidbody2D.simulated = isMove;
    }
}
