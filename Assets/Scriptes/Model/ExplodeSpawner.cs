using UnityEngine;

public class ExplodeSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPullExplosion _pullExplosion;

    public void Spawn(Torpedo torpedo, IInteracteble interacteble)
    {
        Explode explode = _pullExplosion.GetObject();
        explode.transform.position = torpedo.transform.position;

        torpedo.Exploded -= Spawn;

        explode.gameObject.SetActive(true);
    }
}
