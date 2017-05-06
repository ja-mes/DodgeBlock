using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    void Awake()
    {
        Application.targetFrameRate = 50;
    }
}
