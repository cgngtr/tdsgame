using UnityEngine;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour
{

    
    public GameObject bulletPrefab;
    public GameObject gun;
    public Transform gunAttackPoint;
    private float attackCooldown = 0.5f;
    private float attackTimer;
    private float attackRange = 10f;

    public List<Transform> nearestEnemies = new List<Transform>();

    void Start()
    {
        gunAttackPoint = GameObject.Find("GunAttackPoint").GetComponent<Transform>();

        if (bulletPrefab == null || gunAttackPoint == null)
        {
            Debug.LogError("BulletPrefab or GunAttackPoint not assigned or found.");
        }
    }

    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }

        UpdateNearestEnemiesList();

        nearestEnemies.RemoveAll(enemy => enemy == null || IsEnemyDead(enemy));

        if (Attackable() && nearestEnemies.Count > 0)
        {
            Shoot();
            attackTimer = attackCooldown;
        }

        Transform nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            Vector3 directionToEnemy = nearestEnemy.position - transform.position;
            float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg;
            gun.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void UpdateNearestEnemiesList()
    {
        nearestEnemies.RemoveAll(enemy => enemy == null || Vector3.Distance(transform.position, enemy.position) > attackRange);

        Transform newEnemy = FindNearestEnemy();
        if (newEnemy != null && !nearestEnemies.Contains(newEnemy))
        {
            nearestEnemies.Add(newEnemy);
        }
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

    public void Shoot()
    {
        Instantiate(bulletPrefab, gunAttackPoint.position, Quaternion.identity);
    }

    public bool Attackable()
    {
        return attackTimer <= 0;
    }

    private bool IsEnemyDead(Transform enemyTransform)
    {
        EnemyHealth enemyHealth = enemyTransform.GetComponent<EnemyHealth>();
        return enemyHealth != null && enemyHealth.enemyHealth <= 0;
    }
}
