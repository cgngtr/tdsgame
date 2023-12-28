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
    private bool canAttack = true;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
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

    private bool IsNear()
    {
        return distanceFromPlayer <= 0.35f;
    }

    private IEnumerator AttackWithCooldown()
    {
        canAttack = false;
        Debug.Log("Hit");
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
