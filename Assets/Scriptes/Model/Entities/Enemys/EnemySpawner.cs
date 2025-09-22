using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPullEnemy _objectPull;
    [SerializeField] private ObjectPullTorpedoes _objectPullTorpedoes;
    [SerializeField] private ObjectPullExplosion _objectPullExplosion;

    [SerializeField] private float _upperLimit;
    [SerializeField] private float _lowerLimit;
    [SerializeField] private float _enemySpeed;

    [SerializeField] private float _spawnInterval;

    private Coroutine _coroutine;

    public void StartSpawn()
    {
        _coroutine = StartCoroutine(Spawn());
    }

    public void StopSpawn()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnInterval);

        while (enabled)
        {
            EnemySubmarine enemy = _objectPull.GetObject();
            enemy.gameObject.SetActive(true);
            enemy.transform.position = new Vector3(transform.position.x, Random.Range(_lowerLimit, _upperLimit), transform.position.z);
            enemy.GetComponent<EnemyAttacker>().SetParams(_objectPullTorpedoes);
            enemy.GetComponent<EnemyMover>().SetParams(_enemySpeed);
            enemy.GetComponent<Exploder>().SetExplosionPool(_objectPullExplosion);
            
            yield return waitForSeconds;
        }
    }
}