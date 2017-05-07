using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public ParticleSystem ps;
	public float shieldDuration = 6f;
	private GameManager gm;

	void Start() 
	{
		gm = GameObject.FindObjectOfType<GameManager>();
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") 
		{
			gm.playerHasShield = true;

			Invoke("ResetShield", shieldDuration);
		}

    }

	void ResetShield()
	{
		gm.playerHasShield = false;
	}

}
