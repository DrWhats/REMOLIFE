using System;
using System.IO;
using System.Linq;
using UnityEngine;

public static class UserReader
{
    private string _path = Application.persistentDataPath + "/Users"; 
    private string[] _playerList;
    public player _currentPlayer;
    
    static void loadPlayer(string name)
    {
        _currentPlayer = new player(name);
    }

    private static void CheckAndCreate()
    {
        if (getPlayers() == null)
        {
            createPlayer("Player");
        }
    }
    
    public static void CreatePlayer(string name)
    {
        player newPlayer = new player(name);
        SavePlayerToJson(newPlayer);
    }
    
    private static void LoadPlayerFromJson(string name)
    {
        string json = File.ReadAllText(_path + "/" + name + ".json");
        _currentPlayer = JsonUtility.FromJson<player>(json);
    }
    
    public static string[] GetPlayersList()
    {
        _usersList = Directory.GetFiles(_path, "*.json")
            .Select(Path.GetFileName)
            .ToArray();
        
        return _usersList;
    }
    
    public static void DeletePlayer(string name)
    {
        File.Delete(String.Format("{0}/{1}.json", _path, name));
    }
    
    public void SavePlayerToJson(player player)
    {
        string json = JsonUtility.ToJson(player);
        File.WriteAllText(Application.persistentDataPath + "/" + name.ToString()+".json", json);
    }
}
