using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPlate : MonoBehaviour
{
    [SerializeField] private string _playerName;
    [SerializeField] private TextMeshProUGUI _playerNameText;
    [SerializeField] private TextMeshProUGUI _playerDayText;
    [SerializeField] private UserReader _userReader;
    [SerializeField] private GameObject _MainMenu;

    [SerializeField] private string playerName
    {
        get => _playerName;
        set => _playerName = value;
    }
    
    [SerializeField] private int _playerDay;
    public int playerDay
    {
        get => _playerDay;
        set => _playerDay = value;
    }

    private void Awake()
    {
         _userReader = FindObjectOfType<UserReader>();
    }
    
    public void SetCurrentPlayer()
    {
       player Player = _userReader.GetPlayerFromJson(playerName);
       _userReader.ShowMainMenu();
       _userReader.SetCurrentPlayer(Player);
    }
    
    public void SetPlayer(player player)
    {
        _playerName = player.name;
        _playerDay = player.day;
        _playerNameText.text = _playerName;
        _playerDayText.text = _playerDay.ToString();
    }
}
