using System.Collections.Generic;
using UnityEngine;

public class BouncingBullet : MonoBehaviour, IBullet
{
    [SerializeField] private float bulletSpeed;

    [SerializeField] private List<Transform> targets;
    private int currentTargetIndex = 0;
    private Transform currentTarget;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (targets.Count > 0)
        {
            currentTarget = targets[currentTargetIndex];
        }
    }
    private void Update()
    {
        if (currentTarget != null)
        {
            MoveTowardsTarget();
        }
    }
    public void Shoot() => MoveTowardsTarget();



    private void MoveTowardsTarget()
    {
        if (currentTarget != null)
        {
            Vector3 direction = (currentTarget.position - transform.position).normalized;
            rb.velocity = direction * bulletSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyAnimation enemy = other.GetComponent<EnemyAnimation>();
        if (enemy != null)
        {
            enemy.StartShake();
        
            currentTargetIndex++;
            if (currentTargetIndex < targets.Count)
            {
                currentTarget = targets[currentTargetIndex];
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}
