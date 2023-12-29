using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private PlayerExperience _PlayerExperience;
    public int enemyHealth;
    public static Object[] objects;

    void Start()
    {
        _PlayerExperience = GameObject.Find("Player").GetComponent<PlayerExperience>();
        enemyHealth = 5;
    }

    void Update()
    {
        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Dead");
            _PlayerExperience.GainExperience(40);
        }
    }

    public void DealDamage(int damage)
    {
        Debug.Log("a");
        enemyHealth -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Damage dealt.");
            DealDamage(1);
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
    }
}
