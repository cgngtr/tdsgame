using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private int[] enemiesToSpawn;

    private void Start()
    {
        enemiesToSpawn = new int[] { 1, 2, 3, 4, 5 };
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (_GameManager.RoundStarting() && _GameManager.enemies.Count <= 0)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < enemiesToSpawn[_GameManager.round - 1]; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            _GameManager.AddEnemyToList(newEnemy);
        }
    }
}
