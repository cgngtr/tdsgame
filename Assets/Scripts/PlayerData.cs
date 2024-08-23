using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    PlayerExperience _playerExperience;
    EnemyValueSet _enemyValueSet;
    PlayerAttack _playerAttack;
    public int level;
    public int damage;
    public int enemyIndex;
    public int xp;
    public PlayerData data;

    public void Awake()
    {
        _playerExperience = GameObject.Find("Player").GetComponent<PlayerExperience>();
        _enemyValueSet = GameObject.Find("SpawnManager").GetComponent<EnemyValueSet>();
        _playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();

        data = new PlayerData(_playerExperience.currentLevel, _playerExperience.currentExperience,
            _enemyValueSet.enemyToSpawn, _playerAttack.playerDamage);
    }

    public PlayerData()
    {
    }

    public PlayerData(int level, int damage, int enemyIndex, int xp)
    {
        this.level = level;
        this.damage = damage;
        this.enemyIndex = enemyIndex;
        this.xp = xp;
    }
}
