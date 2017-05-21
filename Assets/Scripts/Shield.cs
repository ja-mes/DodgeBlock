using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public ParticleSystem ps;
    private float shieldDuration = 6f;
	private bool shieldState = true;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Globals.GM.playerHasShield = true;

            Invoke("ResetShield", shieldDuration);
			Invoke("StartShieldBlink", shieldDuration - 2);
        }

    }

    void ResetShield()
    {
        Globals.GM.playerHasShield = false;
    }

    void StartShieldBlink()
    {
		StartCoroutine(BlinkShield());
    }
    IEnumerator BlinkShield()
    {
        print("BlinkShield");

        while(Globals.GM.playerHasShield)
		{
            yield return new WaitForSeconds(0.2f);
			shieldState = !shieldState;
			GameObject.FindObjectOfType<Player>().ChangeShieldColor(shieldState);
			print("body exe");
		}
    }

}
