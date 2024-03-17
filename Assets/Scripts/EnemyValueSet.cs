using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyValueSet : MonoBehaviour
{

    public Enemy _Enemy;
    public GameManager _gameManager;
    public EnemySpawner _enemySpawner;
    public EnemyHealth _enemyHealth;
    public bool spawnable;
    public float multiplier;
    public int enemyToSpawn;
    public int enemySpawnAmount;


    void Start()
    {
        enemySpawnAmount = 5; enemyToSpawn = 0;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _enemySpawner = GameObject.Find("SpawnManager").GetComponent<EnemySpawner>();
    }

    public void Update()
    {
        switch (_gameManager.round)
        {
            case 0:
                // _enemySpawner.enemiesPerWave = 5; _enemyHealth.enemyHealth += 0; _enemyHealth.playerDamage = 1; multiplier = 1.5f;
                enemySpawnAmount = 5; enemyToSpawn = 0; break;
            case 1:
                // _enemySpawner.enemiesPerWave = 8; _enemyHealth.enemyHealth += 3 ; _enemyHealth.playerDamage = 2; multiplier = 1.5f;
                enemySpawnAmount = 5; enemyToSpawn = 1; break;

            case 2:
                // _enemySpawner.enemiesPerWave = 10; _enemyHealth.enemyHealth += 6; _enemyHealth.playerDamage = 3; multiplier = 1.5f; 
                enemySpawnAmount = 5; enemyToSpawn = 2; break;

            case 3:
                // _enemySpawner.enemiesPerWave = 12; _enemyHealth.enemyHealth += 9; _enemyHealth.playerDamage = 4; multiplier = 1.5f; 
                enemySpawnAmount = 5; enemyToSpawn = 3; break;

            case 4:
                // _enemySpawner.enemiesPerWave = 15; _enemyHealth.enemyHealth += 12; _enemyHealth.playerDamage = 5; multiplier = 1.5f; 
                enemySpawnAmount = 5; enemyToSpawn = 4; break;

            case 5:
                // _enemySpawner.enemiesPerWave = 18; _enemyHealth.enemyHealth += 15; _enemyHealth.playerDamage = 6; multiplier = 1.5f; 
                enemySpawnAmount = 5; enemyToSpawn = 5; break;

            case 6:
                // _enemySpawner.enemiesPerWave = 20; _enemyHealth.enemyHealth += 18; _enemyHealth.playerDamage = 7; multiplier = 1.5f; 
                enemySpawnAmount = 5; enemyToSpawn = 6; break;

            case 7:
                // _enemySpawner.enemiesPerWave = 22; _enemyHealth.enemyHealth += 21; _enemyHealth.playerDamage = 8; multiplier = 1.5f; 
                enemySpawnAmount = 5; enemyToSpawn = 7; break;

            case 8:
                // _enemySpawner.enemiesPerWave = 25; _enemyHealth.enemyHealth += 24; _enemyHealth.playerDamage = 9; multiplier = 1.5f; 
                enemySpawnAmount = 5; enemyToSpawn = 8; break;

            case 9:
                // _enemySpawner.enemiesPerWave = 30; _enemyHealth.enemyHealth += 27; _enemyHealth.playerDamage = 10; multiplier = 1.5f; 
                enemySpawnAmount = 5; enemyToSpawn = 9; break;

            default:
                break;
        }
    }

    public int EnemySpawnable()
    {




        return 0;
    }
}
