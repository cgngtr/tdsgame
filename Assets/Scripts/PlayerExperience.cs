using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    public int currentExperience;
    public int currentLevel = 1;
    [SerializeField] private int experienceToLevelUp = 50;

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
        // 65
        currentExperience -= experienceToLevelUp;
        experienceToLevelUp += 50;
        Debug.Log($"Leveled up! You're now level {currentLevel}");
    }
}
