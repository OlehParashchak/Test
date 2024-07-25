using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private float flashDuration ;
    [SerializeField] private float shakeDuration ;
    [SerializeField] private float shakeMagnitude ;

    private float shakeTimer = 0f;
    private Vector3 originalPosition;
    private bool isShaking = false;

    private void Start() => originalPosition = transform.localPosition;

    private void Update()
    {
        if (isShaking)
        {
            if (shakeTimer > 0)
            {
                float x = Random.Range(-1f, 1f) * shakeMagnitude;
                float y = Random.Range(-1f, 1f) * shakeMagnitude;

                transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
                shakeTimer -= Time.deltaTime;
            }
            else
            {
                isShaking = false;
                transform.localPosition = originalPosition;
            }
        }
    }

    public void StartShake()
    {
        isShaking = true;
        shakeTimer = shakeDuration;
    }
}
