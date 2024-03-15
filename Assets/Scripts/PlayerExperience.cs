using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    public int currentExperience;
    public int currentLevel = 1;
    [SerializeField] private int experienceToLevelUp = 50;
    [SerializeField] private List<UpgradeData> upgrades;
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

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }


        return upgradeList;
    }
}