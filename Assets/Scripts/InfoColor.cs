using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoColor : MonoBehaviour
{
    public Image shieldImage;

    bool infoState = false;

    Color32 shieldColor = new Color32(255, 69, 0, 33);
    bool fadeOneColor = false;

    void Start()
    {
        shieldImage.color = Color.clear;
    }

    void Update() 
    {
        if (fadeOneColor)
        {
            shieldImage.color = Color.Lerp(shieldColor, Color.clear, Mathf.PingPong(Time.time * 3, 1));
        }
    }

    public void ResetInfoColorInTime(string type, float time)
    {
        Invoke("ResetShield", time);
        Invoke("StartInfoColorBlink", time - 2);
    }


    private void ResetShield()
    {
        Globals.GM.playerHasShield = false;
        fadeOneColor = false;
        shieldImage.color = Color.clear;
    }

    public void ChangeInfoColor()
    {
        if (Globals.GM.playerHasShield)
        {
            shieldImage.color = new Color32(255, 69, 0, 33);
        }
        else
        {
            shieldImage.color = Color.clear;
        }
    }

    public void StartInfoColorBlink()
    {
        fadeOneColor = true;
    }
}