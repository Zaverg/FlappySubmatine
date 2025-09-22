using UnityEngine;

public class EnemyMover : Mover
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

    public override void Move()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
