using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    private bool isActive = true;
    private TrailRenderer trailRenderer;

    private void Awake() => trailRenderer = GetComponent<TrailRenderer>();

    private void OnCollisionEnter(Collision collision)
    {
        if (!isActive) return;
        isActive = false;

        GetComponent<Rigidbody>().useGravity = true;

        if (trailRenderer)
        {
            trailRenderer.emitting = false;
        }
    }
}
