using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private PlayerExperience _PlayerExperience;
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private EnemySpawner _EnemySpawner;
    public int enemyHealth;

    void Start()
    {
        _PlayerExperience = GameObject.Find("Player").GetComponent<PlayerExperience>();
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _EnemySpawner = GameObject.Find("SpawnManager").GetComponent<EnemySpawner>();

        enemyHealth = 5;
    }

    void Update()
    {
        
    }

    public void DealDamage(int damage)
    {
        Debug.Log("a");
        if (enemyHealth <= 1)
        {
            enemyHealth -= damage;
            StartCoroutine(DieCoroutine());
        }
        else
        {
            enemyHealth -= damage;

        }
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

    public IEnumerator DieCoroutine()
    {
        _EnemySpawner.enemiesList.Remove(gameObject);
        Debug.Log("Dead");
        _PlayerExperience.GainExperience(40);
        yield return null;
        Destroy(gameObject);
    }
}
