using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPullEnemy _objectPull;
    [SerializeField] private ObjectPullTorpedos _objectPullTorpedos;
    [SerializeField] private ExplodeSpawner _explodeSpawner;

    [SerializeField] private float _upperLimit;
    [SerializeField] private float _lowerLimit;
    [SerializeField] private float _enemySpeed;

    [SerializeField] private float _intensity;

    private Coroutine _corutine;

    public void StartSpawn()
    {
        _corutine = StartCoroutine(Spawn());
    }

    public void StopSpawn()
    {
        StopCoroutine(_corutine);
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_intensity);

        while (enabled)
        {
            EnemySubmarine enemy = _objectPull.GetObject();
            enemy.gameObject.SetActive(true);
            enemy.transform.position = new Vector3(transform.position.x, Random.Range(_lowerLimit, _upperLimit), transform.position.z);
            enemy.GetComponent<EnemyAttacker>().SetParams(_objectPullTorpedos);
            enemy.GetComponent<EnemyMover>().SetParams(_enemySpeed);
            
            yield return waitForSeconds;
        }
    }
}