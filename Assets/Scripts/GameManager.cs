using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    
    Player player;

    bool _playerHasShield = false;
    public bool playerHasShield
    {
        get
        {
            return _playerHasShield;
        }

        set
        {
            if (player)
            _playerHasShield = value;
            player.ChangeShieldColor(_playerHasShield);
        }
    }


    void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        Globals.GM = this;
        Globals.Player = player;
        Application.targetFrameRate = 50;
    }

    public void Reset()
    {
        playerHasShield = false;
        // for slow down blocks
        Time.timeScale = 1;
    }
}