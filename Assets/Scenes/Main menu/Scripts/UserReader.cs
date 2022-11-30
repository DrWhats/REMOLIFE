using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

class UserReader: MonoBehaviour
{
    private string _path = null;
    private string[] _playerList;
    private player _currentPlayer;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _createPanel;
    [SerializeField] private GameObject _PlayersPanel;
    [SerializeField] private GameObject _playerPlatePrefab;
    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TextMeshProUGUI _playerDay;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _continueButton;
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
                playerPlate.GetComponentInChildren<PlayerPlate>().SetPlayer(GetPlayerFromJson(player));
            }
        }
    }
    
    public void ShowMainMenu() {
        _mainPanel.SetActive(true);
        _PlayersPanel.SetActive(false);
        _createPanel.SetActive(false);
    }

    void CheckForPath()
    {
        if (!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
            Debug.Log("Created Directory");
            CreatePlayer("Player");
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
    
    public player GetPlayerFromJson(string name)
    {
        string json = File.ReadAllText(_path + "/" + name + ".json");
        player tempPlayer = JsonUtility.FromJson<player>(json);
        return tempPlayer;
    }
    
    public void SetCurrentPlayer(player player)
    {
        _currentPlayer = player;
        LoadPlayerData();

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
    
    public void LoadPlayerData()
    {
        _playerName.text = _currentPlayer.name;
        _playerDay.text = "День "+ _currentPlayer.day.ToString();
        if (_currentPlayer.day == 0) {
            _continueButton.SetActive(false);
            _startButton.SetActive(true);
        }
        else {
            _continueButton.SetActive(true);
            _startButton.SetActive(false);
        }
    }
    
}
