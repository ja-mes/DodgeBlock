using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoColor : MonoBehaviour
{
    public Image shieldImage;

    bool infoState = false;


    public void ResetInfoColorInTime(float time) 
    {
        Invoke("ResetInfoColor", time);
        Invoke("StartInfoColorBlink", time-2);
    }

    private void ResetInfoColor() 
    {
        Globals.GM.playerHasShield = false;
        Globals.GM.playerHasFreeze = false;
    }

    public void ChangeInfoColor(string type = null)
    {
        if (type == "shield")
        {
            shieldImage.color = new Color32(255, 69, 0, 33);
        }
        else if (type == "freeze")
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
        StartCoroutine(BlinkInfoColor());
    }

    IEnumerator BlinkInfoColor()
    {
        bool hasShield = Globals.GM.playerHasShield;
        bool hasFreeze = Globals.GM.playerHasFreeze;

        if (!hasShield)
            ChangeInfoColor("shield");

        if (!hasFreeze)
            ChangeInfoColor("freeze");

        while (Globals.GM.playerHasShield)
        {
            yield return new WaitForSeconds(0.2f);
            infoState = !infoState;

            if (infoState)
                ChangeInfoColor("shield");
            else
                ChangeInfoColor();
        }

        while (Globals.GM.playerHasFreeze)
        {
            yield return new WaitForSeconds(0.2f);
            infoState = !infoState;

            if (infoState)
                ChangeInfoColor("freeze");
            else
                ChangeInfoColor();
        }

        ChangeInfoColor();
    }
}