using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float lineOfSite;
    [SerializeField] private EnemyAttack _EnemyAttack;
    private bool isFacingRight;
    public float distanceFromPlayer;

    void Start()
    {
    }

    void Update()
    {
        #region FLIP
        if (transform.position.x - player.transform.position.x <= 0 && !isFacingRight)
        {
            Flip();
        }

        if (transform.position.x - player.transform.position.x > 0 && isFacingRight)
        {
            Flip();
        }
        #endregion

        distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > _EnemyAttack.shootingRange)
        {
            Debug.Log("A");
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, _EnemyAttack.shootingRange);
    }
}
