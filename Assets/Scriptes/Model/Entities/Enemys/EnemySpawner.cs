using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPullEnemy _objectPull;
  
    [SerializeField] private float _upperLimit;
    [SerializeField] private float _lowerLimit;
    [SerializeField] private float _enemySpeed;

    [SerializeField] private float _spawnInterval;

    private Coroutine _coroutine;

    public void StartSpawn()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnInterval);

        while (enabled)
        {
            EnemySubmarine enemy = _objectPull.GetObject();
            enemy.SetParams(_enemySpeed);
            enemy.transform.position = new Vector3(transform.position.x, Random.Range(_lowerLimit, _upperLimit), transform.position.z);
            
            yield return waitForSeconds;
        }
    }
}