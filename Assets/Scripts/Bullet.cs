using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float lifeTime = 1f;

    private PlayerAttack _playerAttack;
    private Transform currentTarget;

    void Start()
    {
        _playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (currentTarget == null || !IsTargetAlive(currentTarget.gameObject))
        {
            currentTarget = _playerAttack.FindNearestEnemy();
        }

        if (currentTarget != null)
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                 currentTarget.position,
                                                 speed * Time.deltaTime);
    }

    bool IsTargetAlive(GameObject target)
    {
        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        return enemyHealth != null && enemyHealth.enemyHealth > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
