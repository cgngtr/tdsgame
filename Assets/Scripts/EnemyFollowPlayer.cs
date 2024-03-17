using System.Collections;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float distanceFromPlayer;
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackCooldown = 1f;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private bool canAttack = true;
    public LayerMask collisionLayer; // The layer(s) to consider for collision avoidance


    public float avoidanceRadius = 1.5f;
    public float avoidanceForce = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Bounds bounds = boxCollider.bounds;
        Collider2D[] collisions = Physics2D.OverlapBoxAll(bounds.center, bounds.size, 0, collisionLayer);

        foreach (Collider2D collider in collisions)
        {
            if (collider.gameObject != gameObject) // Skip self
            {
                // Calculate a safe position to move to based on the current position and the collider's position
                Vector2 safePosition = CalculateSafePosition(bounds, collider.bounds);

                // Move the enemy to the safe position
                rb.MovePosition(safePosition);
            }
        }



        distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);

        if (canAttack && IsNear())
        {
            StartCoroutine(AttackWithCooldown());
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
                                                     player.transform.position,
                                                     speed * Time.deltaTime);
        }
    }

    Vector2 CalculateSafePosition(Bounds myBounds, Bounds otherBounds)
    {
        // Calculate the direction from the other collider to this collider
        Vector2 direction = myBounds.center - otherBounds.center;

        // Calculate the safe distance to move away from the other collider
        float safeDistance = (myBounds.size.x + otherBounds.size.x) / 2f;

        // Calculate the safe position by adding the direction and the safe distance
        Vector2 safePosition = (Vector2)transform.position + direction.normalized * safeDistance;

        return safePosition;
    }

    private bool IsNear()
    {
        return distanceFromPlayer <= 0.35f;
    }

    private IEnumerator AttackWithCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.color = Color.red; Gizmos.DrawWireSphere(transform.position, avoidanceRadius);
    }
}
