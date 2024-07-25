using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private BulletCreator bulletCreator;

    public void DefaultBullet() => bulletCreator.SetActiveBulletIndex(0);

    public void ExplosivetBullet() => bulletCreator.SetActiveBulletIndex(1);

    public void BouncingBullet() => bulletCreator.SetActiveBulletIndex(2);
}
