using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ObjectPull<BaseExplode> _pullExplosion;

    public void Spawn()
    {
        BaseExplode explode = _pullExplosion.GetObject();
        explode.transform.position = transform.position;

        explode.gameObject.SetActive(true);

    }

    public void SetExplosionPool(ObjectPullExplosion objectPullExplosion)
    {
        _pullExplosion = objectPullExplosion;
    }
}
