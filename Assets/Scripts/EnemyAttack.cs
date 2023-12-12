using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool isInRange = false;
    float nextAttackTime = 0f;
    public Transform attackPoint;
    public float shootingRange;
    public GameObject bullet;
    public float fireRate = 1f;
    public float nextFireTime;
    public float attackCooldown = 0f; // 0 = fireable.
    public float attackTimer;
    public float enemyDamage;
    public GameObject player;
    [SerializeField] private float attackRange; // declare later.
    [SerializeField] private float attackRate = 5f;
    [SerializeField] private float animationDelay = 0.7f;
    [SerializeField] private LayerMask playerLayer;
    private EnemyFollowPlayer _EFP;


    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        _EFP = GetComponent<EnemyFollowPlayer>();
    }

    void Update()
    {
        if(Attackable())
        {
            MeleeAttack();
        }
    }

    public IEnumerator ThrowFireball()
    {
        Debug.Log("Coroutine started!");
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(animationDelay);
        Instantiate(bullet, new Vector3(attackPoint.transform.position.x,
        attackPoint.transform.position.y, attackPoint.transform.position.z), Quaternion.identity);
    }

    public void MeleeAttack()
    {
        // 3 sn bekle
        Debug.Log("Hit");
        // 2 bs
    }

    private bool Attackable()
    {
        //attack range 0.75
        if (_EFP.distanceFromPlayer <= attackRange)
            return true;

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
