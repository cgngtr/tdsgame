using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private PlayerExperience _playerExperience;
    public GameObject upgradeUI;
    [SerializeField] private Button option1;
    [SerializeField] private Button option2;
    [SerializeField] private Button option3;
    [SerializeField] private Button option4;
    public int selectedOption;
    public GameManager _gameManager;

    void Start()
    {
        upgradeUI = GameObject.Find("Level UP UI");
        option1.onClick.AddListener(() => OnOptionClick(1));
        option2.onClick.AddListener(() => OnOptionClick(2));
        option3.onClick.AddListener(() => OnOptionClick(3));
        option4.onClick.AddListener(() => OnOptionClick(4));
    }

    public void Update()
    {

    }

    public void OnOptionClick(int optionNumber)
    {
        selectedOption = optionNumber;
        SelectUpgrade();
    }

    public void SelectUpgrade()
    {
        Debug.Log("Upgrade you chose: " + selectedOption);
        upgradeUI.SetActive(false);
        Time.timeScale = 1f;
        _gameManager.isGamePaused = false;

    }

}