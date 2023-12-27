
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float rotationSpeed = 5f;
    public Transform currentTarget;
    [SerializeField] private EnemyHealth _EnemyHealth;


    void Start()
    {
        _EnemyHealth = GameObject.Find("Enemy").GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (currentTarget == null || !IsTargetAlive(currentTarget.gameObject))
        {
            currentTarget = FindNearestEnemy();
        }



        transform.position = Vector2.MoveTowards(transform.position,
                                                     FindNearestEnemy().transform.position,
                                                     speed * Time.deltaTime);
    }

    void RotateTowardsTarget()
    {
        Vector3 direction = currentTarget.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    public Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            return null;
        }

        Transform nearestEnemy = enemies[0].transform;
        float closestDistance = Vector3.Distance(transform.position, nearestEnemy.position);

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
    }

    bool IsTargetAlive(GameObject target)
    {
        return target.GetComponent<EnemyHealth>().enemyHealth != 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Damage dealt.");
            _EnemyHealth.DealDamage(1);
        }
    }
}