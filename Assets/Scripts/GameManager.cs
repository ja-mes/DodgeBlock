using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public bool playerHasShield = false;

    void Awake()
    {
        Globals.GM = this;
        Application.targetFrameRate = 50;
    }

    public void Reset() {
        playerHasShield = false;
        // for slow down blocks
        Time.timeScale = 1;
    }
}