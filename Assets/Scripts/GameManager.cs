﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    
    Player player;

    bool _playerHasShield = false;
    bool _playerHasFreeze = false;

    public bool playerHasShield
    {
        get
        {
            return _playerHasShield;
        }

        set
        {
            _playerHasShield = value;
        }
    }

    public bool playerHasFreeze
    {
        get
        {
            return _playerHasFreeze;
        }
        set
        {
            _playerHasFreeze = value;
        }
    }

    void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        
        // do not assign to "this" must use FindObjectOfType or this var disappears on second player death
        Globals.GM = GameObject.FindObjectOfType<GameManager>();
        Globals.Player = player;
        Globals.InfoColor = GameObject.FindObjectOfType<InfoColor>();
        Application.targetFrameRate = 50;
    }

    public void ResetSceneWithTimeout(float desTime)
    {
        Invoke("ResetScene", desTime);
    }

    public void ResetScene()
    {
        playerHasShield = false;
        // for slow down blocks
        Time.timeScale = 1;

        SceneManager.LoadScene(2);
    }
}