using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public int round = 0;
    public bool isGamePaused = false;
    public float timer = 30f;
    public EnemySpawner _enemySpawner;

    void Start()
    {
        _enemySpawner = GameObject.Find("SpawnManager").GetComponent<EnemySpawner>();
    }
    
    void Update()
    {
        if (enemies.Count <= 0)
        {
        }

        if (isGamePaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        timer -= Time.deltaTime;
        if(timer  < 0f) 
        {
            round++;
            SceneManager.LoadScene(0);

        }
    }
        

    public void AddEnemyToList(GameObject enemy)
    {
        enemies.Add(enemy);
        Debug.Log(enemy.name);
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
            Debug.Log("Enemy removed. Remaining enemies: " + enemies.Count);
        }
        else
        {
            Debug.LogWarning("Attempted to remove an enemy that was not in the list.");
        }
    }
}