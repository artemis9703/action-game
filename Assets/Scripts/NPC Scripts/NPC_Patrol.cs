using UnityEngine;
using System.Collections;

public class NPC_Patrol : MonoBehaviour
{
    public Vector2[] patrolPoints;
    private int currentPatrolIndex;
    public Vector2 target;
    public float speed = 2;
    private Rigidbody2D rb;
    public float pauseDuration = 1.5f;
    private bool isPaused;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        StartCoroutine(SetPatrolPoint());
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused == true)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        Vector2 direction = ((Vector3)target - transform.position).normalized;
        if (direction.x < 0 && transform.localScale.x > 0 || direction.x > 0 && transform.localScale.x < 0)
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        rb.linearVelocity = direction * speed;
        if (Vector2.Distance(transform.position, target) < 0.1f)
            StartCoroutine(SetPatrolPoint());
    }

    IEnumerator SetPatrolPoint()
    {
        isPaused = true;
        anim.Play("Idle");
        yield return new WaitForSeconds(pauseDuration);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        target = patrolPoints[currentPatrolIndex];
        isPaused = false;
        anim.Play("Walk");
    }
}