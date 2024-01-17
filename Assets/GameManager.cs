using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public int round = 0;

    void Start()
    {
        StartCoroutine(StartRound());

    }

    void Update()
    {
        if (enemies.Count <= 0)
        {
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

    public bool RoundStarting()
    {
        return true;
    }
    private IEnumerator StartRound()
    {
        yield return new WaitForSeconds(3f);
        round++;
        Debug.Log(round);
        RoundStarting();
        yield return new WaitUntil(() => enemies.Count <= 0);
        StartCoroutine(StartRound());
    }
}