using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float _speed;

    private void Update()
    {
        Move();
    }

    public void SetParams(float speed)
    {
        _speed = speed;
    }

    private void Move()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
