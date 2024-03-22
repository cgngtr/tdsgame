using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonController : MonoBehaviour
{
    public PlayerData _playerData;
    string path = Application.dataPath + "/Saves/userJson.json";

    private void Awake()
    {
        _playerData = new PlayerData();

    }

    private void Start()
    {
        SaveJson();
    }

    public void SaveJson()
    {
        string jsonString = JsonUtility.ToJson(_playerData.data);
        File.WriteAllText(path,jsonString);
    }
    
    public void LoadJson()
    {
        if(File.Exists(path))
        {
            string jsonRead = File.ReadAllText(path);
            _playerData.data = JsonUtility.FromJson<PlayerData>(jsonRead);
        }
        else
        {
            Debug.Log("File not found.");
        }
    }
}
