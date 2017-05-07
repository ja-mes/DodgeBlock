using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text score;

    void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();

        if (gm != null)
        {
            score.text = "SCORE: " + gm.score.ToString();
        }
    }
}
