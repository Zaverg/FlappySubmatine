using System.Collections.Generic;
using UnityEngine;

public class ObjectPull<T> : MonoBehaviour where T: Component, IReliseble
{
    [SerializeField] private T _object;
    private Queue<T> _pool;
    private List<T> _allObject = new List<T>();

    public IEnumerable<T> ObjectPool => _pool;

    public void Reset()
    {
        for (int i = _allObject.Count - 1; i >= 0; i--)
        {
            T obj = _allObject[i];
            obj.Realesed -= PutObject;
            Destroy(obj.gameObject);
        }

        _allObject.Clear();
        _pool.Clear();
    }

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public virtual T GetObject()
    {
        if (_pool.Count == 0)
        {
            T obj = Instantiate(_object);
            obj.Realesed += PutObject;
            _allObject.Add(obj);

            return obj;
        }

        return _pool.Dequeue();
    }

    public virtual void PutObject(IReliseble relised)
    {
        T obj = relised as T;

        if (obj != null)
        {
            _pool.Enqueue(obj);
            obj.gameObject.SetActive(false);
        }
    }
}
