using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// Bir timer olacak, timer bitene kadar dusmanlar spawnlanmaya devam edecek.

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameManager _gameManager;

    public float roundTime = 30f;
    private Text timerText;

    public List<GameObject> enemiesList = new List<GameObject>();
    public int enemiesPerWave = 5;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(Spawn());
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
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        //timerText.text = timerString;
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < enemiesPerWave; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab[0], GetRandomSpawnPosition(), Quaternion.identity);
            enemiesList.Add(enemy);
        }
        yield return null;
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