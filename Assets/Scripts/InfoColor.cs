using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoColor : MonoBehaviour
{
    public Image shieldImage;

    bool infoState = false;


    void Start()
    {
        shieldImage.color = Color.clear;
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
    }

    private void ResetFreeze()
    {
        Globals.GM.playerHasFreeze = false;
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
        shieldImage.color = Color.clear;
    }

    public void StartInfoColorBlink()
    {
        StartCoroutine(BlinkInfoColor());
    }

    IEnumerator BlinkInfoColor()
    {
        bool hasShield = Globals.GM.playerHasShield;
        bool hasFreeze = Globals.GM.playerHasFreeze;

        while (Globals.GM.playerHasShield)
        {
            yield return new WaitForSeconds(0.2f);
            infoState = !infoState;

            if (infoState)
                ChangeInfoColor();
            else
                ClearInfoColor();
        }

        while (Globals.GM.playerHasFreeze)
        {
            yield return new WaitForSeconds(0.2f);
            infoState = !infoState;

            if (infoState)
                ChangeInfoColor();
            else
                ClearInfoColor();
        }

        ClearInfoColor();
    }
}