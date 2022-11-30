using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

class UserReader: MonoBehaviour
{
    private string _path = null;
    private string[] _playerList;
    [SerializeField] private player _currentPlayer;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _createPanel;
    [SerializeField] private GameObject _PlayersPanel;
    [SerializeField] private GameObject _playerPlatePrefab;

    private void Start()
    {
        _path = Application.persistentDataPath + "/Users"; 
        CheckForPath();
        _playerList = GetPlayersList();
        if (_playerList.Length == 0) {
            //_createPanel.SetActive(true);
        } 
        else {
            _PlayersPanel.SetActive(true);
            _mainPanel.SetActive(false);
            foreach (var player in _playerList) {
                var playerPlate = Instantiate(_playerPlatePrefab, _PlayersPanel.transform);
                Debug.Log(player);
                playerPlate.GetComponentInChildren<TextMeshProUGUI>().text = player;
            }
        }
    }

    void CheckForPath()
    {
        if (!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
            Debug.Log("Created Directory");
            CreatePlayer("Player");
            LoadPlayerFromJson("Player");
            Debug.Log(_path);
        }
        else
        {
            Debug.Log("Directory already exists");
            Debug.Log(_path);
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
            .Select(Path.GetFileNameWithoutExtension)
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
        File.WriteAllText(_path + "/" + player.name.ToString()+".json", json);
    }
}
