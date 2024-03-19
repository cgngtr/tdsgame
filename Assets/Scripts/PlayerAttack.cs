using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    
    [SerializeField] private float attackRange = 10f;
    public GameObject bulletPrefab;
    public GameObject gun;
    public Transform gunAttackPoint;
    private float attackCooldown = 0.5f;
    private float attackTimer;
    public Animator anim;
    public int playerDamage;
    public List<Transform> nearestEnemies = new();
    public EnemySpawner _enemySpawner;

    void Start()
    {
        _enemySpawner = GameObject.Find("SpawnManager").GetComponent<EnemySpawner>();
        gunAttackPoint = GameObject.Find("GunAttackPoint").GetComponent<Transform>();
        anim = GameObject.Find("Gun").GetComponent<Animator>();
        playerDamage = 5;

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

        foreach (GameObject enemy in _enemySpawner.enemiesList)
        {
            if (enemy != null && !nearestEnemies.Contains(enemy.transform) && Vector3.Distance(transform.position, enemy.transform.position) <= attackRange)
            {
                nearestEnemies.Add(enemy.transform);
            }
        }
    }

    public Transform FindNearestEnemy()
    {
        if (_enemySpawner.enemiesList.Count == 0)
        {
            return null;
        }

        Transform nearestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemyObject in _enemySpawner.enemiesList)
        {
            if (enemyObject != null)
            {
                float distance = Vector3.Distance(transform.position, enemyObject.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestEnemy = enemyObject.transform;
                }
            }
        }

        return nearestEnemy;
    }



    public void Shoot()
    {
        Transform nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, gunAttackPoint.position, Quaternion.identity);
            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            if (bulletComponent != null)
            {
                bulletComponent.SetTarget(nearestEnemy);
            }
        }
        anim.SetTrigger("isShooting");
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
