using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public ParticleSystem ps;
	public float shieldDuration = 6f;

	void Start() 
	{
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") 
		{
			Globals.GM.playerHasShield = true;

			Invoke("ResetShield", shieldDuration);
		}

    }

	void ResetShield()
	{
		Globals.GM.playerHasShield = false;
	}

}
