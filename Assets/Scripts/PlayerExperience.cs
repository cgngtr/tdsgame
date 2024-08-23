using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    public int currentExperience;
    public int currentLevel = 1;
    [SerializeField] private int experienceToLevelUp = 50;
    [SerializeField] private List<ItemData> items;
    public bool isLeveledUp;
    public GameObject upgradeUI;
    public GameManager _gameManager;


    private void Awake()
    {
        upgradeUI.SetActive(true);
    }

    void Start()
    {
        upgradeUI = GameObject.Find("Level UP UI");
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (upgradeUI != null)
        {
            upgradeUI.SetActive(false);
        }
        else
        {
            Debug.LogError("Upgrade UI reference is not assigned!");
        }
    }

    void Update()
    {

    }

    public void GainExperience(int amount)
    {
        currentExperience += amount;
        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if (currentExperience >= experienceToLevelUp)
        {
            isLeveledUp = true;
            LevelUp();

        }
        else
        {
            isLeveledUp = false;
        }
    }

    void LevelUp()
    {
        currentLevel++;
        currentExperience -= experienceToLevelUp;
        experienceToLevelUp += 50;
        isLeveledUp = false;
        upgradeUI.SetActive(true);
        Time.timeScale = 0f;
        _gameManager.isGamePaused = true;
        
    }

    public List<ItemData> GetUpgrades(int count)
    {
        List<ItemData> upgradeList = new List<ItemData>();

        if (count > items.Count)
        {
            count = items.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(items[Random.Range(0, items.Count)]);
        }


        return upgradeList;
    }
}