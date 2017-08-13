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

    void Start()
    {
        shieldImage.color = Color.clear;
    }

    void Update()
    {

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