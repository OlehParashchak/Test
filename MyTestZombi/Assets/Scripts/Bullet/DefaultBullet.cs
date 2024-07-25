using UnityEngine;

public class DefaultBullet : MonoBehaviour, IBullet
{
    public float BulletSpeed { get; set; } = 20f;

    public void Shoot() => GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;

    private void OnCollisionEnter(Collision collision) => Destroy(gameObject);
}
