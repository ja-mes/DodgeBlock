using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    public int score;

    void Awake()
    {
        Application.targetFrameRate = 50;
    }
}
