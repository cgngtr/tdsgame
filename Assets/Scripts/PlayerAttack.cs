using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunAttackPoint;
    private float attackCooldown = 0.5f;
    private float attackTimer;


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

        if (Attackable())
        {
            Debug.Log("attackTimer = " + attackTimer);
            Shoot();
            attackTimer = attackCooldown;
        }
    }

    public void Shoot()
    {
        Debug.Log("Shot");
        Instantiate(bulletPrefab, gunAttackPoint.position, Quaternion.identity);
    }

    public bool Attackable()
    {
        return attackTimer <= 0;
    }
}
