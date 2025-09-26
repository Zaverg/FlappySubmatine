using UnityEngine;

public class ObjectPullEnemy : ObjectPull<EnemySubmarine> 
{
    [SerializeField] private ObjectPullTorpedoes _objectPullTorpedoes;
    [SerializeField] private ObjectPullExplosion _objectPullExplosion;

    public override EnemySubmarine GetObject()
    {
        EnemySubmarine enemySubmarine = base.GetObject();
        enemySubmarine.SetObjectPulls(_objectPullTorpedoes, _objectPullExplosion);
        enemySubmarine.gameObject.SetActive(true);

        return enemySubmarine;
    }
}