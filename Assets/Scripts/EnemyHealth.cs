using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private PlayerExperience _PlayerExperience;
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private EnemySpawner _EnemySpawner;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private Enemy _Enemy;
    public int enemyHealth;
    public int playerDamage = 3;

    void Start()
    {
        _PlayerExperience = GameObject.Find("Player").GetComponent<PlayerExperience>();
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _EnemySpawner = GameObject.Find("SpawnManager").GetComponent<EnemySpawner>();
        _playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        enemyHealth = _Enemy.Health;
    }

    void Update()
    {

    }

    public void DealDamage(int damage)
    {
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
            DealDamage(_playerAttack.playerDamage);
            Debug.Log(_playerAttack.playerDamage + " damage dealt.");
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator DieCoroutine()
    {
        _EnemySpawner.enemiesList.Remove(gameObject);
        Debug.Log(Time.timeScale);
        _PlayerExperience.GainExperience(40);
        yield return null;
        Destroy(gameObject);
    }
}