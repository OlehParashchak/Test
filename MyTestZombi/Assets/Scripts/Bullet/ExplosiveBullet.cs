using DG.Tweening;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour, IBullet
{
    [SerializeField] private float bulletSpeed;

    [SerializeField] private GameObject explosionEffect;

    public void Shoot() => GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

    public void TriggerExplosion()
    {
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();

                explosion.transform.DOScale(Vector3.zero, 5f).OnComplete(() =>
                {
                    Destroy(explosion);
                });
            }
        }
    }
}
