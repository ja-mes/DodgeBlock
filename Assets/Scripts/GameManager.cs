using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            _playerHasShield = value;
            if (player)
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