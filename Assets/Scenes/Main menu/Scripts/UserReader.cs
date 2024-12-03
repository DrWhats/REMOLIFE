using System;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

class UserReader: MonoBehaviour
{
    private string _path = null;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _playerPanel;
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
        GameState.PlayerList = GetPlayersList();
        if (GameState.PlayerList.Length == 0) {
            //_createPanel.SetActive(true);
        } 
        else {
            _PlayersPanel.SetActive(true);
            _playerPanel.SetActive(false);
            _mainPanel.SetActive(false);
            foreach (var player in GameState.PlayerList) {
                var playerPlate = Instantiate(_playerPlatePrefab, _PlayersPanel.transform);
                playerPlate.GetComponentInChildren<PlayerPlate>().SetPlayer(GetPlayerFromJson(player));
            }
        }
    }
    
    public void ShowMainMenu() {
        _mainPanel.SetActive(true);
        _playerPanel.SetActive(true);
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
        GameState.Player = player;
        LoadPlayerData();

    }
    
    public string[] GetPlayersList()
    {
        GameState.PlayerList = Directory.GetFiles(_path, "*.json")
            .Select(Path.GetFileNameWithoutExtension)
            .ToArray();
        
        return GameState.PlayerList;
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
        _playerName.text = GameState.Player.name;
        _playerDay.text = "День "+ GameState.Player.day.ToString();
        if (GameState.Player.day == 0) {
            _continueButton.SetActive(false);
            _startButton.SetActive(true);
        }
        else {
            _continueButton.SetActive(true);
            _startButton.SetActive(false);
        }
    }
    
}
