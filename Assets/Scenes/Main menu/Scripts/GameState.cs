using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    private static player player;
    private static string[] _playerList;
    public static player Player { get => player; set => player = value; }
    public static string[] PlayerList { get => _playerList; set => _playerList = value; }
}