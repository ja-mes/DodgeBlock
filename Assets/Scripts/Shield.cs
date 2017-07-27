using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public ParticleSystem ps;
    private Player player;
    private float shieldDuration = 6f;
	private bool shieldState = true;

    void Start()
    {
		player = GameObject.FindObjectOfType<Player>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Globals.GM.playerHasShield = true;

            player.ChangeShieldColor(true);

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
        bool hasShield = Globals.GM.playerHasShield;

        if (!hasShield)
			player.ChangeShieldColor(false);

		while (Globals.GM.playerHasShield)
		{
			yield return new WaitForSeconds(0.2f);
			shieldState = !shieldState;
			player.ChangeShieldColor(shieldState);
		}


        player.ChangeShieldColor(false);
    }

}
