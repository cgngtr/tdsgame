using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// Bir timer olacak, timer bitene kadar dusmanlar spawnlanmaya devam edecek.

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameManager _gameManager;
    public EnemyValueSet _evs;

    public float roundTime = 30f;
    public TextMeshProUGUI timerText;
    public string timerString;

    public List<GameObject> enemiesList = new();
    public int enemiesPerWave = 5;
    public int enemiesPerSpawn = 5;

    void Start()
    {
        _evs = GameObject.Find("SpawnManager").GetComponent<EnemyValueSet>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(StartSpawning());
    }

    void Update()
    {
        if (roundTime > 0)
        {
            roundTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            Debug.Log("Round bitti!");
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(roundTime / 60f);
        int seconds = Mathf.FloorToInt(roundTime % 60f);
        timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }

    IEnumerator StartSpawning()
    {
        while (true)
        {
            Debug.Log("Start spawning method is called.");
            if (_evs == null)
                Debug.Log("_evs not found.");
            Debug.Log (_evs.enemySpawnAmount);
            Debug.Log(_evs.enemyToSpawn);
            Spawn(_evs.enemyToSpawn,_evs.enemySpawnAmount);
            yield return new WaitForSeconds(5f);
        }
    }
    public void Spawn(int index, int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab[index], GetRandomSpawnPosition(), Quaternion.identity);
            enemiesList.Add(enemy);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Implement your own logic to get a random spawn position
        // This can be within a specific range or based on predefined spawn points
        float x = Random.Range(-7f, 7f);
        float y = Random.Range(-3f, 3f);
        return new Vector3(x, y, 0f);
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        enemiesList.Remove(enemy);
    }
    //IEnumerator StartNextWaveDelay()
    //{
    //    isWaveInProgress = true; // Set the flag to indicate that the next wave is starting
    //    yield return new WaitForSeconds(timeBetweenWaves);
    //    StartNextWave();
    //    isWaveInProgress = false; // Reset the flag when the wave starts
    //}
}