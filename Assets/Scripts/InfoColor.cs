using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoColor : MonoBehaviour
{
    public Image shieldImage;

    Color32 shieldColor = new Color32(255, 69, 0, 33);

    bool blink = false;

    float _shieldResetTime;
    float _freezeResetTime;

    public float shieldResetTime
    {
        get
        {
            return _shieldResetTime;
        }
        set 
        {
            _shieldResetTime = value;
        }
    }

    public float freezeResetTime
    {
        get 
        {
            return _freezeResetTime;
        }
        set
        {
            _freezeResetTime = value;
        }
    }

    void Start()
    {
        shieldImage.color = Color.clear;
    }

    void Update()
    {

        if (Globals.GM.playerHasFreeze)
        {
            freezeResetTime -= Time.deltaTime;

            if (freezeResetTime <= 0)
                ResetFreeze();
        }

        if (Globals.GM.playerHasShield)
        {
            shieldResetTime -= Time.deltaTime;

            if(shieldResetTime <= 2)
                blink = true;

            if (shieldResetTime <= 0)
                ResetShield();
        }

        if (blink)
        {
            shieldImage.color = Color.Lerp(shieldColor, Color.clear, Mathf.PingPong(Time.time * 3, 1));
        }
    }

    private void ResetShield()
    {
        shieldResetTime = 0;
        Globals.GM.playerHasShield = false;
        blink = false;
        shieldImage.color = Color.clear;
    }

    private void ResetFreeze()
    {
        Time.timeScale = 1;
        freezeResetTime = 0;
        Globals.GM.playerHasFreeze = false;
    }

    public void ChangeInfoColor()
    {
        if (Globals.GM.playerHasShield)
        {
            shieldImage.color = shieldColor;
        }
        else
        {
            shieldImage.color = Color.clear;
        }
    }
}