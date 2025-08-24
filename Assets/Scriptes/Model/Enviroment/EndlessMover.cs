using System.Collections.Generic;
using UnityEngine;

public class EndlessMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _backgrounds = new List<Transform>();

    [SerializeField] private float _startPositionX;
    [SerializeField] private float _endPositionX;
    [SerializeField] private float _speed;

    private List<Vector2> _restartPosition = new List<Vector2>();

    private float _direction = -1;

    public void Reset()
    {
        for (int i = 0; i < _backgrounds.Count; i++)
        {
            _backgrounds[i].position = _restartPosition[i];
        }
    }

    private void Awake()
    {
        foreach (Transform background in _backgrounds)
        {
            _restartPosition.Add(background.position);
        }    
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        foreach (Transform border in _backgrounds)
        {
            border.Translate(_direction * _speed * Time.deltaTime, 0, 0);

            if (border.position.x <= _endPositionX)
                border.position = new Vector3(_startPositionX, border.position.y, border.position.z);
        }
    }
}
