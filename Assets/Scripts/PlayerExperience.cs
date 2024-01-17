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


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GainExperience(int amount)
    {
        currentExperience += amount;
        CheckLevelUp();
        Debug.Log($"EXP : {currentExperience}");
    }

    void CheckLevelUp()
    {
        if(currentExperience >=  experienceToLevelUp)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentLevel++;
        currentExperience -= experienceToLevelUp;
        experienceToLevelUp += 50;
        Debug.Log($"Leveled up! You're now level {currentLevel}");
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if(count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        for(int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }


        return upgradeList;
    }
}
