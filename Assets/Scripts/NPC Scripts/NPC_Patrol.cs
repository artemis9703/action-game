using UnityEngine;
using System.Collections;

public class NPC_Patrol : MonoBehaviour
{
    public Vector2[] patrolPoints;
    private int currentPatrolIndex;
    public Vector2 target;
    public float speed = 2;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = patrolPoints[currentPatrolIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = ((Vector3)target - transform.position).normalized;
        rb.linearVelocity = direction * speed;
        if (Vector2.Distance(transform.position, target) < 0.1f)
            SetPatrolPoint();
    }

    private void SetPatrolPoint()
    {
        currentPatrolIndex = currentPatrolIndex + 1;
        target = patrolPoints[currentPatrolIndex];
    }
}
