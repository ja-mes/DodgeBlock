using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour {

    public ParticleSystem part;
	public int scoreAmountToAdd = 10;

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			Globals.Player.IncScore(10);			
			Destroy(gameObject);
            ParticleSystem newPart = Instantiate(part, transform.position, Quaternion.identity);
			newPart.Play();
		}
	}
}
