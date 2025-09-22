using System.Collections.Generic;
using UnityEngine;

public class EndlessMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _backgrounds = new List<Transform>();

    [SerializeField] private float _loopStartX;
    [SerializeField] private float _loopEndX;
    [SerializeField] private float _speed;

    private List<Vector2> _restartPositions = new List<Vector2>();

    private float _direction = -1;

    public void Reset()
    {
        for (int i = 0; i < _backgrounds.Count; i++)
        {
            _backgrounds[i].position = _restartPositions[i];
        }
    }

    private void Awake()
    {
        foreach (Transform background in _backgrounds)
        {
            _restartPositions.Add(background.position);
        }    
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        foreach (Transform background in _backgrounds)
        {
            background.Translate(_direction * _speed * Time.deltaTime, 0, 0);

            if (background.position.x <= _loopEndX)
                background.position = new Vector3(_loopStartX, background.position.y, background.position.z);
        }
    }
}
