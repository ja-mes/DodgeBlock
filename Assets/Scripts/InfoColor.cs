using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoColor : MonoBehaviour
{
    public Image shieldImage;

    bool infoState = false;

    Color32 shieldColor = new Color32(255, 69, 0, 33);
    Color32 freezeColor = new Color32(60, 158, 225, 33);
    Color32 colorToFade;
    bool fadeOneColor = false;

    void Start()
    {
        shieldImage.color = Color.clear;
    }

    void Update() 
    {
        if (fadeOneColor)
        {
            shieldImage.color = Color.Lerp(colorToFade, Color.clear, Mathf.PingPong(Time.time * 3, 1));
        }
    }

    public void ResetInfoColorInTime(string type, float time)
    {
        if (type == "shield")
            Invoke("ResetShield", time);
        else if (type == "freeze")
            Invoke("ResetFreeze", time);

        Invoke("StartInfoColorBlink", time - 2);
    }


    private void ResetShield()
    {
        Globals.GM.playerHasShield = false;
        ClearInfoColor();
    }

    private void ResetFreeze()
    {
        Globals.GM.playerHasFreeze = false;
        if (!Globals.GM.playerHasShield)
            ClearInfoColor();
        else
            ChangeInfoColor();
    }

    public void ChangeInfoColor()
    {
        if (Globals.GM.playerHasShield && Globals.GM.playerHasFreeze)
        {
            shieldImage.color = new Color32(171, 77, 255, 33);
        }
        else if (Globals.GM.playerHasShield)
        {
            shieldImage.color = new Color32(255, 69, 0, 33);
        }
        else if (Globals.GM.playerHasFreeze)
        {
            shieldImage.color = new Color32(60, 158, 225, 33);
        }
        else
        {
            shieldImage.color = Color.clear;
        }
    }

    private void ClearInfoColor()
    {
        fadeOneColor = false;
        shieldImage.color = Color.clear;
    }

    public void StartInfoColorBlink()
    {
        fadeOneColor = true;
        colorToFade = shieldImage.color;
    }
}