using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab in the Inspector
    public int numberOfWaves = 5;
    public int enemiesPerWave = 5;
    public float timeBetweenWaves = 3f;

    public List<GameObject> enemiesList = new List<GameObject>();
    private int currentWave = 0;
    private bool isWaveInProgress = false;

    void Start()
    {
        StartNextWave();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all enemies in the current wave are destroyed and if the wave is not in progress
        if (enemiesList.Count == 0 && !isWaveInProgress)
        {
            if (currentWave < numberOfWaves)
            {
                StartCoroutine(StartNextWaveDelay());
            }
            else
            {
                Debug.Log("All waves completed!");
            }
        }
    }

    IEnumerator StartNextWaveDelay()
    {
        isWaveInProgress = true; // Set the flag to indicate that the next wave is starting
        yield return new WaitForSeconds(timeBetweenWaves);
        StartNextWave();
        isWaveInProgress = false; // Reset the flag when the wave starts
    }

    void StartNextWave()
    {
        currentWave++;
        Debug.Log("Wave " + currentWave);

        // Spawn enemies for the current wave
        for (int i = 0; i < enemiesPerWave; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            enemiesList.Add(enemy);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Implement your own logic to get a random spawn position
        // This can be within a specific range or based on predefined spawn points
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-5f, 5f);
        return new Vector3(x, y, 0f);
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        enemiesList.Remove(enemy);
    }
}