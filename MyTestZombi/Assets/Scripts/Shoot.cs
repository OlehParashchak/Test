using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private BulletCreator bulletCreator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bulletCreator.CanShoot)
        {
            StartCoroutine(bulletCreator.ShootBullet());
        }
    }
}
