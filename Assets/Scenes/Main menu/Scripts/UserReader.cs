using System;
using System.IO;
using System.Linq;
using UnityEngine;

public static class UserReader
{
    private static string _path = Application.persistentDataPath + "/Users";
    private static string[] _usersList;

    private static void CheckAndCrate()
    {
        // File.Exists(_path + "/player.json") ? GetUsers() : CreateUser("player");
    }
    
    public static void CreateUser(string name)
    {
        File.Create(String.Format("{0}/{1}.json", _path, name));
    }
    
    public static string[] GetUsers()
    {
        _usersList = Directory.GetFiles(_path, "*.json")
            .Select(Path.GetFileName)
            .ToArray();
        
        return _usersList;
    }
}
