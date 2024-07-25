using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private EnemyAnimation enemyAnimation;
    [SerializeField] private ExplosiveBullet exp;
    [SerializeField] private BulletCreator bulletCreator;

    private void OnTriggerEnter(Collider other)
    {
        IBullet bullet = other.GetComponent<IBullet>();

        if (bullet != null)
        {
            int bulletIndex = bulletCreator.CurrentBulletIndex;

            if (bulletIndex == 1)
            {
                exp.TriggerExplosion();
            }
            enemyAnimation.StartShake();

            if (bulletIndex != 2)
            {
                Destroy(other.gameObject);
            }
        }
    }

}
