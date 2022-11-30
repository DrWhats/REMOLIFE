using System;
using System.IO;
using System.Linq;
using UnityEngine;

class UserReader: MonoBehaviour
{
    private string _path = Application.persistentDataPath + "/Users"; 
    private string[] _playerList;
    [SerializeField] private player _currentPlayer;
    [SerializeField] private GameObject _createPanel;
    [SerializeField] private GameObject _PlayersPanel;

    private void Start()
    {
        CheckForPath();
        _playerList = GetPlayersList();
        if (_playerList.Length == 0) {
            _createPanel.SetActive(true);
        } 
        else {
            _PlayersPanel.SetActive(true);
        }

    }

    void CheckForPath()
    {
        if (!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
        }
    }

    public void CreatePlayer(string name)
    {
        player newPlayer = new player(name);
        SavePlayerToJson(newPlayer);
    }
    
    public void LoadPlayerFromJson(string name)
    {
        string json = File.ReadAllText(_path + "/" + name + ".json");
        _currentPlayer = JsonUtility.FromJson<player>(json);
    }
    
    public string[] GetPlayersList()
    {
        _playerList = Directory.GetFiles(_path, "*.json")
            .Select(Path.GetFileName)
            .ToArray();
        
        return _playerList;
    }
    
    public void DeletePlayer(string name)
    {
        File.Delete(String.Format("{0}/{1}.json", _path, name));
    }
    
    public void SavePlayerToJson(player player)
    {
        string json = JsonUtility.ToJson(player);
        File.WriteAllText(Application.persistentDataPath + "/" + name.ToString()+".json", json);
    }
}
