using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI xp;
    [SerializeField] private PlayerExperience _PlayerExperience;

    private void Awake()
    {
        UpdateLevelXP();
    }

    void Start()
    {
        _PlayerExperience = GameObject.Find("Player").GetComponent<PlayerExperience>();
    }

    void Update()
    {
        UpdateLevelXP();
    }

    void UpdateLevelXP()
    {
        level.text = $"Level : {_PlayerExperience.currentLevel}";
        xp.text = $"XP : {_PlayerExperience.currentExperience}";
    }

}
