using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;
    void Start()
    {
        enemyHealth = 5;
    }

    void Update()
    {
        Debug.Log(enemyHealth);
        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Dead");
        }
    }

    public void DealDamage(int damage)
    {
        enemyHealth -= damage;
    }

}
