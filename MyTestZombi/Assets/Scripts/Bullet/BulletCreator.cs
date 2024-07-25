using UnityEngine;
using System.Collections;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPrefabs;

    private int currentBulletIndex;
    private float fireRate;

    private bool canShoot;
    public bool CanShoot => canShoot;
    public int CurrentBulletIndex => currentBulletIndex;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        canShoot = true;
        currentBulletIndex = 0;
        fireRate = 1f;
    }

    public IEnumerator ShootBullet()
    {
        canShoot = false;

        GameObject bulletPrefab = bulletPrefabs[currentBulletIndex];
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        IBullet bullet = newBullet.GetComponent<IBullet>();
        if (bullet != null)
        {
            bullet.Shoot();
        }

        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
    public void SetActiveBulletIndex(int index) => currentBulletIndex = index;
}

